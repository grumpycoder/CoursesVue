var careerTechUrl = '/api/careertech/';
var courseUrl = '/api/courses/';
var refUrl = '/api/ref/';

Vue.use(VeeValidate,
    {
        classes: true,
        classNames: {
            valid: 'is-valid',
            invalid: 'is-invalid'
        }
    });

var app = new Vue({
    el: '#app',
    data: {
        urlParam: null,
        selectedProgram: null,
        program: null,
        cachedProgram: null,
        programs: [],
        clusters: [],
        programTypes: [],
        schoolYears: [],
        credentials: [],
        courses: [],
        programCredentials: null,
        programCourses: null,
        selectedCourse: null,
        selectedCredential: null,
    },
    methods: {
        create: function () {
            this.program = {
                clusterId: null,
                programTypeId: null,
                beginYear: null
            };
            this.cachedProgram = Object.assign({}, {});
            //this.$validator.fields.items.forEach(r => {
            //    console.log(r);
            //});
            //this.$validator.validateAll().then((r) => {
            //    console.log(r);
            //});
            //this.$validator.attach({ name: 'clusterName', rules: 'required' });
            //this.$validator.attach({ name: 'clusterCode', rules: 'required' });
            //this.$validator.attach({ name: 'clusterTypeId', rules: 'required' });
            //this.$validator.attach({ name: 'beginYear', rules: 'required' });
            //this.$validator.attach({ name: 'endYear', rules: 'greaterThan:beginYear' });
        },
        submit: function (e) {
            if (this.program.id == undefined) {
                axios.post(careerTechUrl + 'programs', this.program)
                    .then(resp => {
                        this.program = resp.data;
                        this.cachedProgram = Object.assign({}, this.program);

                        var program = {
                            programName: this.program.name,
                            programCode: this.program.programCode
                        }
                        this.programs.push(program);
                        this.selectedProgram = program;

                        this.$validator.reset();

                    });

            } else {
                axios.put(careerTechUrl + 'programs', this.program)
                    .then(resp => {
                        this.selectedProgram.programName = this.program.name;
                        this.selectedProgram.programCode = this.program.programCode;

                        this.cachedProgram = Object.assign({}, this.program);
                        this.$validator.reset();

                    });
            }
        },

        onChange: function (e) {
            this.getProgram(this.selectedProgram.programCode);
        },

        deleteCredential: function (credential) {
            var idx = this.programCredentials.indexOf(credential);
            var url = careerTechUrl +
                'programs/' +
                this.selectedProgram.programCode +
                '/credential/' +
                credential.credentialCode;
            axios.delete(url)
                .then(resp => {
                    this.programCredentials.splice(idx, 1);
                });
        },

        addCredential: function () {
            var url = careerTechUrl +
                'programs/' +
                this.selectedProgram.programCode +
                '/credential/' +
                this.selectedCredential.credentialCode;
            axios.post(url)
                .then(resp => {
                    var dto = resp.data;
                    this.programCredentials.push(dto);
                });
        },

        addCourse: function () {
            var url = careerTechUrl +
                'programs/' +
                this.selectedProgram.programCode +
                '/course/' +
                this.selectedCourse.courseCode;
            axios.post(url)
                .then(resp => {
                    var dto = resp.data;
                    this.programCourses.push(dto);
                }).catch(err => console.log(err));;
        },

        removeCourse: function (course) {
            var idx = this.programCourses.indexOf(course);
            var url = careerTechUrl +
                'programs/' +
                this.selectedProgram.programCode +
                '/course/' +
                course.courseCode;
            axios.delete(url)
                .then(resp => {
                    this.programCourses.splice(idx, 1);
                }).catch(err => console.log(err));;
        },

        getProgram: function (programCode) {
            var fetch = careerTechUrl + 'programs/' + programCode + '/edit';
            var fetchCredentials = careerTechUrl + 'programs/' + programCode + '/credentials';
            var courseUrl = careerTechUrl + 'programs/' + programCode + '/courses';

            this.program = {};

            axios.get(fetch)
                .then(resp => {
                    this.program = resp.data;

                    this.$validator.reset();
                    this.cachedProgram = Object.assign({}, resp.data);

                }).then(resp => {
                    axios.get(courseUrl).then(resp => {
                        this.programCourses = resp.data;
                    }).catch(err => console.log(err));
                }).then(resp => {

                    axios.get(fetchCredentials).then(resp => {
                        this.programCredentials = resp.data;
                    }).catch(err => console.log(err));

                });
        },

        cancel: function () {
            this.program = Object.assign({}, this.cachedProgram);
            this.$validator.reset();
        },

    },
    computed: {
        isFormDirty() {
            return Object.keys(this.fields).some(key => this.fields[key].dirty);
        }
    },
    created() {
        this.urlParam = urlParam;
        var courseOptions = '?loadOptions.filter=isActive%3Dtrue&loadOptions.remoteSelect=true';

        axios.get(refUrl + 'schoolyears').then(resp => {
            this.schoolYears = resp.data;
        }).catch(err => console.log(err));

        axios.get(refUrl + 'clusters').then(resp => {
            this.clusters = resp.data;
        }).catch(err => console.log(err));

        axios.get(refUrl + 'programs').then(resp => {
            this.programs = resp.data;
        }).then(() => {
            if (urlParam !== null) {
                this.selectedProgram = this.programs.find(x => x.programCode === urlParam);
                this.getProgram(urlParam);
            }
        }).catch(err => console.log(err));

        axios.get(refUrl + 'programTypes').then(resp => {
            this.programTypes = resp.data;
        }).catch(err => console.log(err));

        axios.get(refUrl + 'credentials').then(resp => {
            this.credentials = resp.data;
        }).catch(err => console.log(err));

        axios.get(courseUrl + courseOptions).then(resp => {
            this.courses = resp.data.data;
        }).catch(err => console.log(err));

        this.$validator.extend('greaterThan',
            (value, otherValue) => {
                console.log('value', value);
                console.log('otherValue', otherValue);

                return value >= otherValue;
            },
            {
                hasTarget: true
            });

    },
    mounted() {

    }
});

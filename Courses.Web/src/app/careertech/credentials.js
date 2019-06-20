
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
        selectedCredential: null,
        credential: null,
        cachedCredential: null,
        credentials: [],
        schoolYears: [],
        credentialTypes: [],
        programs: [],
    },
    methods: {
        create: function () {
            this.credential = {
                credentialTypeId: null,
                beginYear: null
            };
            this.cachedCredential = Object.assign({}, {});
        },

        submit: function (e) {
            if (this.credential.id == undefined) {
                axios.post(careerTechUrl + 'credentials', this.credential)
                    .then(resp => {
                        console.log('resp', resp);
                        this.credential = resp.data;
                        console.log('credential', this.credential);
                        this.cachedCredential = Object.assign({}, this.credential);
                        this.credentials.push(this.credential);
                        this.selectedCredential = this.credential;

                        this.$validator.reset();
                    });
            } else {
                axios.put(careerTechUrl + 'credentials', this.credential)
                    .then(resp => {
                        var e = this.credentials.find(x => x.id === resp.data.id);
                        this.selectedCredential.name = resp.data.name;
                        this.selectedCredential.credentialCode = resp.data.credentialCode;
                    });
            }


        },

        onChange: function (e) {
            this.getCredential(this.selectedCredential.credentialCode);
        },

        getCredential: function (credentialCode) {
            var url = careerTechUrl + 'credentials/' + credentialCode;

            this.credential = {};

            axios.get(url + '/edit').then(resp => {
                this.credential = resp.data;

                this.$validator.reset();
                this.cachedCredential = Object.assign({}, resp.data);
            }).then(resp => {
                axios.get(url + '/programs').then(resp => {
                    this.programs = resp.data;
                }).catch(err => console.log(err));

            }).catch(err => console.log(err));
        },

        cancel: function () {
            this.credential = Object.assign({}, this.cachedCredential);
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

        axios.get(refUrl + 'credentials').then(resp => {
            this.credentials = resp.data;
        }).then(() => {
            if (urlParam !== null) {
                this.selectedCredential = this.credentials.find(x => x.credentialCode === urlParam);
                this.getCredential(urlParam);
            }
        }).catch(err => console.log(err));

        axios.get(refUrl + 'schoolyears').then(resp => {
            this.schoolYears = resp.data;
        }).catch(err => console.log(err));

        axios.get(refUrl + 'credentialTypes').then(resp => {
            this.credentialTypes = resp.data;
        }).catch(err => console.log(err));

        this.$validator.extend('greaterThan',
            (value, otherValue) => {
                return value >= otherValue;
            },
            {
                hasTarget: true
            });

    },
    mounted() {

    }
});

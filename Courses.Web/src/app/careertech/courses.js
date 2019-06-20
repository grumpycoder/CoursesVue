
var careerTechUrl = '/api/careertech/';
var courseUrl = '/api/courses';
var refUrl = '/api/ref/';


var app = new Vue({
    el: '#app',
    data: {
        urlParam: null,
        course: null,
        selectedProgram: null,
        courses: [],
        programs: [],
        coursePrograms: [],
    },
    methods: {
        onChange: function (e) {
            var url = careerTechUrl + 'courses/' + this.course.courseCode + '/programs';
            axios.get(url).then(resp => {
                this.coursePrograms = resp.data;
            }).catch(err => console.log(err));

        },
        removeProgram: function (program) {
            var url = careerTechUrl + 'programs/' + program.programCode + '/course/' + this.course.courseCode;
            var idx = this.coursePrograms.indexOf(program);
            axios.delete(url)
                .then(resp => {
                    this.coursePrograms.splice(idx, 1);

                });
        },

        addProgram: function () {
            var url = careerTechUrl +
                'programs/' +
                this.selectedProgram.programCode +
                '/course/' +
                this.course.courseCode;
            axios.post(url)
                .then(resp => {
                    this.coursePrograms.push(this.selectedProgram);
                });
        },

        getPrograms(courseCode) {
            var url = careerTechUrl + 'courses/' + courseCode + '/programs';
            axios.get(url).then(resp => {
                this.coursePrograms = resp.data;
            }).catch(err => console.log(err));
        }

    },
    created() {
        this.urlParam = urlParam;
        var courseOptions = '?skip=5&take=5';

        axios.get(courseUrl + courseOptions).then(resp => {
            this.courses = resp.data.data;
        }).then(() => {
            if (urlParam !== null) {
                this.course = this.courses.find(x => x.courseCode === urlParam);
                this.getPrograms(urlParam);
            }
        }).catch(err => console.log(err));

        axios.get(refUrl + 'programs').then(resp => {
            this.programs = resp.data;
        }).catch(err => console.log(err));

    },
    mounted() {
    }
});

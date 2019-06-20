
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
        clusterCode: null,
        selectedCluster: null,
        cluster: null,
        cachedCluster: null,
        clusters: [],
        schoolYears: [],
        clusterTypes: [],
        programs: []
    },
    watch: {
    },
    methods: {
        create: function () {
            this.cluster = {
                clusterTypeId: null,
                beginYear: null
            };
            this.cachedCluster = Object.assign({}, {});
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
            if (this.cluster.id == undefined) {
                axios.post(careerTechUrl + 'clusters', this.cluster)
                    .then(resp => {
                        this.cluster = resp.data;
                        this.cachedCluster = Object.assign({}, this.cluster);
                        this.clusters.push(this.cluster);
                        this.selectedCluster = this.cluster;

                        this.$validator.reset();
                    });
            } else {
                axios.put(careerTechUrl + 'clusters', this.cluster)
                    .then(resp => {
                        this.selectedCluster.name = this.cluster.name;
                        this.selectedCluster.clusterCode = this.cluster.clusterCode;

                        this.cachedCluster = Object.assign({}, this.cluster);
                        this.$validator.reset();
                    });
            }
        },

        onChange: function (e) {
            if (this.selectedCluster !== null) {
                this.getCluster(this.selectedCluster.clusterCode);
            } else {
                this.cluster = null;
            }
        },

        cancel: function () {
            this.cluster = Object.assign({}, this.cachedCluster);
            this.$validator.reset();
        },

        getCluster(clusterCode) {
            var url = careerTechUrl + 'clusters/' + clusterCode;
            this.cluster = {};

            axios.get(url + '/edit').then(resp => {
                this.cluster = resp.data;
                this.$validator.reset();
                this.cachedCluster = Object.assign({}, resp.data);

            }).then(resp => {
                axios.get(url + '/programs').then(resp => {
                    this.programs = resp.data;
                }).catch(err => console.log(err));
            })
                .catch(err => console.log(err));
        },
    },
    computed: {
        isFormDirty() {
            return Object.keys(this.fields).some(key => this.fields[key].dirty);
        },
        isFormInValid() {
            return Object.keys(this.fields).some(key => this.fields[key].invalid);
        }
    },
    created() {
        axios.get(refUrl + 'schoolyears').then(resp => {
            this.schoolYears = resp.data;
        }).catch(err => console.log(err));

        axios.get(refUrl + 'clustertypes').then(resp => {
            this.clusterTypes = resp.data;
        }).catch(err => console.log(err));

        axios.get(refUrl + 'clusters').then(resp => {
            this.clusters = resp.data;
        }).then(() => {
            if (urlParam !== null) {
                this.selectedCluster = this.clusters.find(x => x.clusterCode === urlParam);
                this.getCluster(urlParam);
            }
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

        //Custom Validator
        //this.$validator.extend('greaterThan',
        //    (value, otherValue) => {

        //        //var valueObj = this.schoolYears.find(x => x.id == value);
        //        //var otherObj = this.schoolYears.find(x => x.id == otherValue);
        //        //if (valueObj !== undefined && otherObj !== undefined) {
        //        //    return valueObj.year > otherObj.year;
        //        //}
        //        //return true;
        //    },
        //    {
        //        hasTarget: true
        //    });


    },
    updated() {
    },
    beforeMount() {
    },
    mounted() {
    }
});

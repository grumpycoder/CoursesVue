(function() {
    console.log('details ready');
    
    var currentUrl = window.location.pathname.split('/');
    var courseCode = currentUrl[currentUrl.length - 1]; 
    var url = '/api/courses/' + courseCode;
    var course = {}; 

    //axios.get(url).then(resp => {
    //    course = resp.data;
    //    //console.log('course', course);
    //}).catch(err => console.log(err));



})();
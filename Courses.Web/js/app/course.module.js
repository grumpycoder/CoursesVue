(function () {
    console.log('ready');


    var uri = "/api/courses";

    var $grid = $('#grid').dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: 'id',
            loadUrl: uri
        }),
        remoteOperations: true,
        allowColumnResizing: true,
        allowColumnReordering: true,
        showBorders: true,
        wordWrapEnabled: true,
        'export': {
            enabled: true,
            fileName: "Courses",
            allowExportSelectedData: false,
            icon: 'fa fa-trash'
        },
        stateStoring: {
            enabled: false,
            type: "localStorage",
            storageKey: "gridCourseFilterStorage"
        },
        filterRow: { visible: true },
        headerFilter: { visible: true },
        groupPanel: { visible: true },
        scrolling: { mode: "virtual", rowRenderingMode: "virtual" },
        paging: { pageSize: 5 },
        height: 650,
        columnChooser: { enabled: true },
        columnResizingMode: "nextColumn",
        columnMinWidth: 50,
        columnAutoWidth: true,
        columns: [
            'courseCode', 
            'cipCode',
            'name', 
            'description', 
            'beginServiceYear', 
            'endServiceYear', 
            'lowGrade', 
            'highGrade',
            'status', 
            'courseType', 
            'classType', 
            'creditType',
            'subjectArea',
            {
                cellTemplate: function(container, item) {
                    $('<a/>').addClass('btn btn-outline-primary')
                        .text('Details')
                        .attr('aria-label', 'Details')
                        .attr('href', '/courses/' + item.data.courseCode)
                        .on('dxclick',
                            function (e) {
                                console.log('click', item.data);
                            })
                        .appendTo(container);
                }
            }]
    }).dxDataGrid("instance");
})();
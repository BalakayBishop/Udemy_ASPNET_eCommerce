
$("document").ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/products/getall' },
        "columns": [
            { data: 'title', "width": "20%" },
            { data: 'author', "width": "15%" },
            { data: 'isbn', "width": "10%" },
            { data: 'listPrice', "width": "15%" },
            { data: 'category.name', "width": "15%" },
        ]
    });
}

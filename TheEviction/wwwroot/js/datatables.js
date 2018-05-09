//datatables.js
//Nameless function that executes immediately. Self-Executed Anonymous Function Or Immediately Invoked Function Expression to avoid the global scope problem.
// by wrapping it up in parenthesis, it becomes a big expression.
(function () {
    $('#tblClient').DataTable();
})();
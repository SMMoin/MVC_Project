$(document).ready(function () {
    loadData();
});
function loadData() {
    $.ajax({
        url: "/CommitteMember/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.MemberID + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Age + '</td>';
                html += '<td>' + item.Address + '</td>';
                html += '<td>' + item.ContactNo + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.MemberID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.MemberID + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        Id: $('#MemberID').val(),
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        Address: $('#Address').val(),
        ContactNo: $('#ContactNo').val()
    };
    $.ajax({
        url: "/CommitteMember/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function getbyID(ID) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#ContactNo').css('border-color', 'lightgrey');
    $.ajax({
        url: "/CommitteMember/getbyID/" + ID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#MemberID').val(result.MemberID);
            $('#Name').val(result.Name);
            $('#Age').val(result.Age);
            $('#Address').val(result.Address);
            $('#ContactNo').val(result.ContactNo);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        MemberID: $('#MemberID').val(),
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        Address: $('#Address').val(),
        ContactNo: $('#ContactNo').val(),
    };
    $.ajax({
        url: "/CommitteMember/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#MemberID').val("");
            $('#Name').val("");
            $('#Age').val("");
            $('#Address').val("");
            $('#ContactNo').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/CommitteMember/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function clearTextBox() {
    $('#MemberID').val("");
    $('#Name').val("");
    $('#Age').val("");
    $('#Address').val("");
    $('#ContactNo').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#ContactNo').css('border-color', 'lightgrey');
}
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Age').val().trim() == "") {
        $('#Age').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Age').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    }
    if ($('#ContactNo').val().trim() == "") {
        $('#ContactNo').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ContactNo').css('border-color', 'lightgrey');
    }
    return isValid;
}
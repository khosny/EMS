var sectors = [];
function LoadSectors() {
    $.ajax({
        url: "/api/Sector",
        method: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (res) {
            console.log(res);
            $.each(res, function (k, v) {
                $('#drp_Sector').append('<option value="' + v.Id + '">' + v.Name + '</option>');
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
};
function GetSectorObject() {
    var _sector = {};

    _sector.Id = $('#drp_Sector').val();
    _sector.Name = $('#drp_Sector option:selected').text();

    _sector.Start = new Date(new Date($('#txt_Date').val())
        .setHours($('#drp_Start').val(), 0, 0, 0));
    _sector.End = new Date(new Date($('#txt_Date').val())
        .setHours($('#drp_End').val(), 0, 0, 0));

    return _sector;
};
function AddNewPerson(nPerson, url, message) {
    $.ajax({
        url: url,
        method: "POST",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: nPerson,
        success: function (res) {
            alert(message);
            location.reload();
        },
        error: function (err) {
            console.log(res);
        }
    });
};

function LoadPersonOPS(url, successMessage) {
    // load sectors
    LoadSectors();
    $('#txt_Date').datepicker();
    $('#btn_AddSector').click(function () {
        var sector = GetSectorObject();
        sectors.push(sector);
        var from = $('#txt_Date').val() + ' ' + $('#drp_Start option:selected').text();
        var to = $('#txt_Date').val() + ' ' + $('#drp_End option:selected').text();
        $('#tbl_Sectors tbody').append('<tr><td>' + sector.Name + ' ( ' + from + ' : ' + to + ' )</td></tr>');
    });
    $('#btn_AddPerson').click(function () {
        var nPerson = {};
        nPerson.Name = $('#txt_Name').val();
        nPerson.Mobile = $('#txt_Mobile').val();
        nPerson.InterestedSectors = sectors;
        AddNewPerson(JSON.stringify(nPerson), url, successMessage);
    });
};
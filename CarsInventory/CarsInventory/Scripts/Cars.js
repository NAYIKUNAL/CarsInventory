$('.focus').focus();

function DisplayMessage(foData) {
    alert(foData.stMessage);
}

function RemoveCar(fiCarId) {
    if (fiCarId > 0) {
        var isConfirm = confirm("Are you sure want to remove this car?");
        if (isConfirm) {
            $.ajax({
                url: lsRemoveCar + '?fiCarId=' + fiCarId,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (foData) {
                    DisplayMessage(foData);
                    location.reload();
                },
                error: function (data) {
                    console.log(data);
                }
            });
        }
    }
    else {
        alert("Please select atleast One Car from List.")
    }
}

function AddEditCar(fiCarId) {
    $.ajax({
        url: lsAddEditCar + "?fiCarId=" + fiCarId,
        contentType: "application/json; charset=utf-8",
        dataType: "HTML",
        success: function (data) {
            if (data != null) {
                $('#modelContent').html(data);
                $('#addCarModal').modal('show');
            }
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function SaveCarInformation() {
    var inCarId = $('#inCarId').val();
    var stBrand = $('#stBrand').val();
    var stModel = $('#stModel').val();
    var inYear = $('#inYear').val();
    var dcPrice = $('#dcPrice').val();
    var flgIsNew = $('#flgIsNew').val();

    if (stBrand == null || stBrand == "" || stBrand == undefined) {
        alert("Brand mandatory field.")
        return false;
    }

    if (stModel == "" || stModel == null || stModel == undefined) {
        alert("Model mandatory field.")
        return false;
    }

    if (!(inYear > 0) || !(inYear > 1990)) {
        alert("Please enter valid Year.")
        return false;
    }

    if (!(dcPrice > 0)) {
        alert("Price mandatory field.")
        return false;
    }

    $.ajax({
        url: lsSaveCarInformation,
        contentType: "application/json; charset=utf-8",
        data: {
            inCarId: inCarId,
            stBrand: stBrand,
            stModel: stModel,
            inYear: inYear,
            dcPrice: dcPrice,
            flgIsNew: flgIsNew
        },
        dataType: "json",
        success: function (data) {
            alert(data.stMessage);
            $('#addCarModal').modal('hide');
            location.reload();
        },
        error: function (data) {
            console.log(data);
        }
    });
}
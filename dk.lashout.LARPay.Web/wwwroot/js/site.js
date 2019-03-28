function isLoggedIn() {
    return localStorage.token != null;
}

function logout() {
    localStorage.removeItem('token');
    window.location.href = '/';
}

function formatDate(rawDate) {
    var date = new Date(rawDate);
    let formatted_date = zero_prefix(date.getDate(), 2) + "-" + zero_prefix(date.getMonth() + 1, 2) + "-" + date.getFullYear();
    let formattet_time = zero_prefix(date.getHours(), 2) + ":" + zero_prefix(date.getMinutes(), 2);
    return formatted_date + " " + formattet_time;
}

function zero_prefix(number, length) {
    var output = '' + number;
    for (var i = output.length; i < length; i++) {
        output = '0' + output;
    }
    return output;
}

function authPost(url, data) {
    return $.ajax({
        type: "POST",
        url: url,
        data: data,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", 'Bearer ' + localStorage.token);
        }
    }).fail(function (data) {
        warn(data.responseText);
    });
};

function authGet(url) {
    return $.ajax({
        type: "GET",
        url: url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", 'Bearer ' + localStorage.token);
        }
    });
};

function login(identity, pincode) {
    login_request = { "username": "", "pincode": "" };
    login_request.username = identity;
    login_request.pincode = pincode;
    $.post('/customer/login',
        login_request,
        function (data) {
            localStorage.token = data;
            window.location.href = '/';
        }).fail(function () {
            warn("Username and pincode didn't match with anyone in the system.");
        });
};

function warn(warningtext) {
    var warningclone = $('#template-warning').clone();
    warningclone.removeAttr('id');
    warningclone.find('#placeholder-warning-text').replaceWith(warningtext);
    warningclone.show();
    warningclone.appendTo('#alert-area');
};

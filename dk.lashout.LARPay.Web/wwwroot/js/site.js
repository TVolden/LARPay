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
}

function authGet(url) {
    return $.ajax({
        type: "GET",
        url: url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", 'Bearer ' + localStorage.token);
        }
    });
}

function isLoggedIn() {
    return localStorage.token != null;
}

function logout() {
    localStorage.removeItem('token');
    window.location.href = '/';
}

function formatDate(rawDate) {
    var date = new Date(rawDate);
    let formatted_date = date.getDate() + "-" + (date.getMonth() + 1) + "-" + date.getFullYear();
    let formattet_time = date.getHours() + ":" + date.getMinutes();
    return formatted_date + " " + formattet_time;
}

function warn(warningtext) {
    var warningclone = $('#template-warning');
    warningclone.removeAttr('id');
    warningclone.find('#placeholder-for-warning-text').replaceWith(warningtext);
    warningclone.show();
    warningclone.appendTo('#warning-area');
}

function login(identity, pincode) {
    login_request = { "username":"", "pincode":"" };
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
}

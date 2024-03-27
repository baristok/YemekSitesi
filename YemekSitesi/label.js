function redirectToPage() {
    // Yönlendirme işlemi
    window.location.href = "membership.aspx";
}


function showInfo() {
    var label = document.getElementById('<%= Label2.ClientID %>');
    label.innerHTML = "Şifre Değiştirmek İçin Tıklayınız";
}

function hideInfo() {
    var label = document.getElementById('<%= Label2.ClientID %>');
    label.innerHTML = "";
}
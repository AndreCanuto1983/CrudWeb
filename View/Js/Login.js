function validaCampos() {
    if (document.frmLogin.txtUsuario.value === "") {
        alert("Informe o usuário!");
        document.frmLogin.txtUsuario.focus();
        return false;
    }
    if (document.frmLogin.txtSenha.value === "") {
        alert("Informe a senha!");
        document.frmLogin.txtSenha.focus();
        return false;
    }
    var usuario = document.frmLogin.txtUsuario.value;
    var senha = document.frmLogin.txtSenha.value;

    //alert("usuario: "+usuario+ "\n senha: "+senha);
    //limparCamposLogin();
}

function limparCamposLogin() {
    document.frmLogin.txtUsuario.value = "";
    document.frmLogin.txtSenha.value = "";
}

function chamaC_Usuario() {
    location.href = 'C_Usuario.html';
}

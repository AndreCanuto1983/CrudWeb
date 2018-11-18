function validaCampos() {
    if (document.frmC_Usuario.txtUsuario.value == "") {
        alert("Informe o usuário!");
        document.frmC_Usuario.txtUsuario.focus();
        return false;
    }
    if (document.frmC_Usuario.txtSenha.value == "") {
        alert("Informe a senha!");
        document.frmC_Usuario.txtSenha.focus();
        return false;
    }
    if (document.frmC_Usuario.txtSenha1.value == "") {
        alert("Confirme a senha!");
        document.frmC_Usuario.txtSenha1.focus();
        return false;
    }
    if (document.frmC_Usuario.txtEmail.value == "") {
        alert("Informe o e-mail!");
        document.frmC_Usuario.txtEmail.focus();
        return false;
    }
    var usuario = document.frmC_Usuario.txtUsuario.value;
    var senha = document.frmC_Usuario.txtSenha.value;
    var senha1 = document.frmC_Usuario.txtSenha1.value;
    var email = document.frmC_Usuario.txtEmail.value;
    alert("usuario: " + usuario + "\n senha: " + senha + "\n senha1: " + senha1 + "\n e-mail: " + email);
    limparCampos();
}

function limparCampos() {
    document.frmC_Usuario.txtUsuario.value = "";
    document.frmC_Usuario.txtSenha.value = "";
    document.frmC_Usuario.txtSenha1.value = "";
    document.frmC_Usuario.txtEmail.value = "";
}

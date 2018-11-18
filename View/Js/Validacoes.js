function fecharAlerta()
{    
    document.getElementById('subCorpo_DivAlert').style.display = 'none'; //a div muda o id pois está dentro de uma master page
    //document.getElementById('DivAlert').style.display = 'none';
}

function ocultarMenuLateral()
{
    var display = document.getElementById(div).style.display;

    if (display == "none") {
        document.getElementById('MenuLateral').style.display = 'block';
    }
    else
    {
        document.getElementById('MenuLateral').style.display = 'none';
    }        
}

//document.getElementById('MenuLateral').style.display = 'none';
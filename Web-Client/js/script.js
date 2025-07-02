function GetMenu(){
    let menu = '<ul class="navbar-nav me-auto mb-2 mb-lg-0"><li class="nav-item"><a class="nav-link active me-active" href="index.html">Home</a></li><li class="nav-item"><a class="nav-link" href="carros/index.html">Carros</a></li><li class="nav-item"><a class="nav-link" href="funcionarios/index.html">Funcionários</a></li></ul>';
    return menu;
}

function GetURL(){
    return "https://localhost:44360/api/carros";
}

function ShowMensagemErro(status) {
    
    if (status === 400) {
        alert("Erro no envio de dados!");
        return;
    }

    if (status === 404) {
        alert("O registro não foi encontrado!");
        return;
    }

    if (status === 500) {
        alert("Erro interno de servidor! \n Entre em contato com o suporte.");
        return;
    }

    if (status === -100){
        alert("Erro na requisição! \n Entre em contato com o suporte.");
        return;
    }

    alert("Erro na resposta! \n Entre em contato com o suporte.");
}

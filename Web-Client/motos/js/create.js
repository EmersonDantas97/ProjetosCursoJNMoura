function GoToIndex() {
    document.location = 'index.html';
}

function GetMoto() {
    return {
        nome: document.getElementById("nome").value,
        valor: document.getElementById("valor").value
    }
}

function GetURL() {
    return "https://localhost:44360/api/Motos";
}

function ValidarDados(moto) {
    return moto.nome !== "" && moto.valor !== "";
}

function Incluir() {

    const moto = GetMoto(); // 

    const url = GetURL();

    if (ValidarDados(moto)) {

        fetch(url, {
            method: "POST",
            headers: { "content-type": "application/json" },
            body: JSON.stringify(moto)
        })
            .then(
                (response) => {

                    console.log(response);

                    if (response.ok) {
                        alert("Dados incluídos com sucesso!");
                        GoToIndex();
                    }
                    else if (response.status == 400) {
                        alert("Erro no envio de dados!");
                    }
                    else if (response.status == 500) {
                        alert("Erro interno do servidor!\n Entre em contato com o suporte.");
                    }
                    else {
                        console.log("Erro na resposta!\n Entre em contato com o suporte.")
                    }
                }
            )
            .catch(
                (error) => {
                    console.log("Erro na requisição!\n Entre em contato com o suporte.");
                }
            );
    }
    else {
        alert("Por favor, preencha todos os dados!");
    }
}
window.onload = () =>{
    GetInputNome().focus();
}

function GoToIndex() {
    document.location = 'index.html';
}

function GetCarro() {
    return {
        nome: GetInputNome().value,
        valor: GetInputValor().value
    }
}

function Validate(carro) {
    return carro.nome !== "" && carro.valor !== "";
}

function EnableButtonIncluir() {
    GetButtonIncluir().disabled = false;
}

function DisableButtonIncluir() {
    GetButtonIncluir().disabled = true;
}

function GetButtonIncluir() {
    return document.querySelector("#btnIncluir");
}

function GetInputNome() {
    return document.querySelector("#nome");
}

function GetInputValor() {
    return document.querySelector("#valor");
}

function Add() {

    const carro = GetCarro();
    if (!Validate(carro)) {
        alert("Por favor, preencha todos os dados!");
        return;
    }

    Post(carro);
}

function Post(carro) {
    const url = GetURL();
    RequestAPI(url, carro);
}

function RequestAPI(url, carro) {

    DisableButtonIncluir();

    fetch(url, {
        method: "POST",
        headers: { "content-type": "application/json" },
        body: JSON.stringify(carro)
    })
        .then(
            (response) => {

                if (response.ok) {
                    alert('Carro incluído com sucesso!');
                    GoToIndex();
                    return;
                }

                ShowMensagemErro(response.status);

                EnableButtonIncluir();
            }
        )
        .catch(
            (error) => {
                ShowMensagemErro(-100);
                EnableButtonIncluir();
            }
        );
}
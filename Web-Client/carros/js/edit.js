window.onload = () => {
    const id = new URLSearchParams(window.location.search).get("id"); 
    SearchById(id);   
    GetInputNome().focus();
}

function SearchById(id) {
    const url = `${GetURL()}/${id}`;
    RequestAPISearchById(url);
}

function RequestAPISearchById(url) {

    fetch(url)
        .then(
            response => {
                if (response.ok)
                    return response.json();               

                ShowMensagemErro(response.status);
            }
        )
        .then(
            carro => {
                ShowCarro(carro);
            }
        )
        .catch(
            error => {
                ShowMensagemErro(-100);
            }
        );
}

function ShowCarro(carro){
    GetInputId().value = carro.Id;
    GetInputNome().value = carro.Nome;
    GetInputValor().value = carro.Valor;
}

function GetInputId() {
    return document.querySelector("#id");
}

function GetInputNome() {
    return document.querySelector("#nome");
}

function GetInputValor() {
    return document.querySelector("#valor");
}

function GoToIndex(){
    document.location = 'index.html';
}

function Update(){
    const carro = GetCarro();
    if (!Validate(carro)) {
        alert("Por favor, preencha todos os dados!");
        return;
    }

    Put(carro); 
}

function GetCarro() {
    return {
        id: GetInputId().value,
        nome: GetInputNome().value,
        valor: GetInputValor().value
    }
}

function Validate(carro) {
    return carro.nome !== "" && carro.valor !== "";
}

function Put(carro) {    
    const url = `${GetURL()}/${carro.id}`;
    RequestAPIPut(url, carro);
}

function RequestAPIPut(url, carro) {

    DisableButtonAlterar();

    fetch(url, {
        method: "PUT",
        headers: { "content-type": "application/json" },
        body: JSON.stringify(carro)
    })
        .then(
            (response) => {

                if (response.ok) {
                    alert('Carro alterado com sucesso!');
                    GoToIndex();
                    return;
                }

                ShowMensagemErro(response.status);

                EnableButtonAlterar();
            }
        )
        .catch(
            (error) => {
                ShowMensagemErro(-100);
                EnableButtonAlterar();
            }
        );
}

function EnableButtonAlterar() {
    GetButtonAlterar().disabled = false;
}

function DisableButtonAlterar() {
    GetButtonAlterar().disabled = true;
}

function GetButtonAlterar() {
    return document.querySelector("#btnAlterar");
}
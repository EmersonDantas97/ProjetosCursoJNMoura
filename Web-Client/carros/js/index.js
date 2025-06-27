function GoToIndex() {
    document.location = 'index.html';
}

function GoToCreate() {
    document.location = 'create.html';
}

function ConfirmDelete(id) {
    if (confirm(`Deseja excluir o carro ${id}?`)) {
        Delete(id);
    }
}

function Delete(id) {
    const url = `${GetURL()}/${id}`;
    RequestAPIDelete(url, id);
}

function RequestAPIDelete(url, id) {
    fetch(url, {
        method: "DELETE"
    })
        .then(
            response => {

                if (response.ok) {
                    Search();
                    alert(`Carro excluído com sucesso: ${id}`);
                    return;
                }

                ShowMensagemErro(response.status);
            }
        )
        .catch(
            error => {
                ShowMensagemErro(-100);
            }
        );

}

function EnableButtonPesquisar() {
    GetButtonPesquisar().disabled = false;
}

function DisableButtonPesquisar() {
    GetButtonPesquisar().disabled = true;
}

function GetButtonPesquisar() {
    return document.querySelector("#btnPesquisar");
}

function GetBodyTabela() {
    return document.querySelector("#corpo-tabela");
}

function GetInputId() {
    return document.querySelector("#id");
}

function GetInputNome() {
    return document.querySelector("#nome");
}

function Search() {

    const id = GetInputId().value;
    const nome = GetInputNome().value;

    if (id !== "")
        SearchById(id);
    else if (nome !== "")
        SearchByNome(nome);
    else
        SearchAll();
}

function SearchById(id) {
    const url = `${GetURL()}/${id}`;
    RequestAPI(url);
}

function SearchAll() {
    const url = `${GetURL()}/`;
    RequestAPI(url);
}

function SearchByNome(nome) {
    const url = `${GetURL()}/${nome}`;
    RequestAPI(url);
}

function RequestAPI(url) {

    DisableButtonPesquisar();

    fetch(url)
        .then(
            response => {
                if (response.ok)
                    return response.json();
                if (response.status === 404)
                    return null;

                ShowMensagemErro(response.status);
            }
        )
        .then(
            conteudoResposta => {

                if (conteudoResposta === null) {
                    GetBodyTabela().innerHTML = GetCorpoTabelaParaCarroNaoEncontrado();
                    return;
                }

                if (Array.isArray(conteudoResposta)) {
                    GetBodyTabela().innerHTML = GetCorpoTabelaParaCarros(conteudoResposta);
                    return;
                }

                GetBodyTabela().innerHTML = GetCorpoTabelaParaCarro(conteudoResposta);
            }
        )
        .catch(
            error => {
                ShowMensagemErro(-100);
            }
        )
        .finally(
            () => {
                EnableButtonPesquisar();
            }
        );
}

function GetCorpoTabelaParaCarros(carros) {

    if (carros.length > 0) {
        let corpoTabela = "";
        carros.forEach(carro => {
            corpoTabela += GetCorpoTabelaParaCarro(carro);
        });
        return corpoTabela;
    }

    return GetCorpoTabelaParaCarroNaoEncontrado();
}

function GetCorpoTabelaParaCarro(carro) {
    return `<tr><td>${carro.Id}</td><td>${carro.Nome}</td><td><a href="edit.html?id=${carro.Id}"><i class="bi bi-pencil"></i></a></td><td><a href="Javascript:ConfirmDelete(${carro.Id});"><i class="bi bi-trash"></i></a></td></tr>`;
}

function GetCorpoTabelaParaCarroNaoEncontrado() {
    return '<tr><td colspan="4" style="text-align:center">Carro não encontrado!</td></tr>';
}
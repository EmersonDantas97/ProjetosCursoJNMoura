function GoToIndex(){
    document.location = 'index.html';
}

function GoToCreate(){
    document.location = 'create.html';
}

function Delete(id){
    if (confirm(`Deseja excluir o carro ${id}?`)){
        const url = `${GetURL()}/${id}`;
        fetch(url, {
                method: "DELETE"
        })
        .then(                            
            response => {
                if (response.ok) {                                       
                    Search();
                    alert(`Carro excluído com sucesso: ${id}`);                    
                }
                else if (response.status === 400){
                    alert("Erro no envio de dados!");
                }
                else if (response.status === 500){
                    alert("Erro interno de servidor! \n Entre em contato com o suporte.");
                }
                else{
                    alert("Erro na resposta! \n Entre em contato com o suporte.");
                }              
            }
        )
        .catch(            
            error => {
                alert("Erro na requisição! \n Entre em contato com o suporte.");                    
            } 
        );    
    }
}

function EnableButtonPesquisar(){
    GetButtonPesquisar().disabled = false;
}

function DisableButtonPesquisar(){
    GetButtonPesquisar().disabled = true;
}

function GetButtonPesquisar(){
    return document.querySelector("#btnPesquisar");
}

function GetBodyTabela(){
    return document.querySelector("#corpo-tabela");
}

function GetInputId(){
    return document.querySelector("#id");
}

function GetInputNome(){
    return document.querySelector("#nome");
}

function Search(){
    
    const id = GetInputId().value;

    if (id !== "")
        SearchById(id);
    else
        SearchAll();    
}

function SearchById(id){
    
    const url = `${GetURL()}/${id}`;
    
    DisableButtonPesquisar();

    fetch(url)
        .then(                            
            response => {
                if (response.ok)
                    return response.json();                
                if (response.status === 404)                    
                    return null;
            }
        )
        .then(
            carro => {
                let corpoTabela = "";
                if (carro != null){
                    corpoTabela = `<tr><td>${carro.Id}</td><td>${carro.Nome}</td><td><a href="edit.html"><i class="bi bi-pencil"></i></a></td><td><a href="Javascript:Delete(${carro.Id});"><i class="bi bi-trash"></i></a></td></tr>`;                    
                }else{
                    corpoTabela = '<tr><td colspan="4" style="text-align:center">Carro não encontrado!</td></tr>';
                }
                GetBodyTabela().innerHTML = corpoTabela;
            }
        )
        .catch(            
            error => {                
                alert("Erro na requisição! \n Entre em contato com o suporte."); 
            } 
        )
        .finally(
            () => {
                EnableButtonPesquisar();
            }
        );

}

function SearchAll(){
    
    //console.log("Início-Search");

    const url = GetURL();

    DisableButtonPesquisar();

    fetch(url)
        .then(                            
            response => {
                return response.json();
            }
        )
        .then(
            carros => {
                let corpoTabela = "";
                carros.forEach(carro => {
                    //console.log(carro);
                    corpoTabela += `<tr><td>${carro.Id}</td><td>${carro.Nome}</td><td><a href="edit.html"><i class="bi bi-pencil"></i></a></td><td><a href="Javascript:Delete(${carro.Id});"><i class="bi bi-trash"></i></a></td></tr>`;                    
                });
                GetBodyTabela().innerHTML = corpoTabela;
            }
        )
        .catch(            
            error => {
                alert("Erro na requisição! \n Entre em contato com o suporte."); 
            } 
        )
        .finally(
            () => {
                EnableButtonPesquisar();
            }
        );

    //console.log("Fim-Search");
}
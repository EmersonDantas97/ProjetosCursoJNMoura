function GoToIndex(){
    document.location = 'index.html';
}

function GetCarro(){
    return {
        nome: GetInputNome().value,
        valor: GetInputValor().value
    }
}

function Validate(carro){
    return carro.nome !== "" && carro.valor !== "";
}

function EnableButtonIncluir(){
    GetButtonIncluir().disabled = false;
}

function DisableButtonIncluir(){
    GetButtonIncluir().disabled = true;
}

function GetButtonIncluir(){
    return document.querySelector("#btnIncluir");
}

function GetInputNome(){
    return document.querySelector("#nome");
}

function GetInputValor(){
    return document.querySelector("#valor");
}

function Add(){
        
    //console.log("Início-Incluir");

    const url = GetURL();

    const carro = GetCarro();

    //console.log(carro);
    //console.log(JSON.stringify(carro));

    if (Validate(carro)){

        DisableButtonIncluir();

        fetch(url, {
                method: "POST",
                headers: {"content-type":"application/json"},
                body: JSON.stringify(carro)
            })
            .then(                            
                (response) => {                
                    //console.log(response);
                    if (response.ok) {
                        alert('Carro incluído com sucesso!');
                        GoToIndex();
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
                    
                    EnableButtonIncluir();                    
                }                
            )
            .catch(            
                (error) => {
                    //console.log(error);                
                    alert("Erro na requisição! \n Entre em contato com o suporte.");                    
                    EnableButtonIncluir();
                } 
            );       
    }else{
        alert("Por favor, preencha todos os dados!");
    }
    
    //console.log("Fim-Incluir");     
}


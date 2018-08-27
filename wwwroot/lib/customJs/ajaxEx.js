$(function () {
    var $banner = $("#banner-message");
    var $button = $("button");
    var $msg = $("p");
    var $cep = $("#cep"); 

    // service, parameters and get method
    const service = "https://livro-capitulo07.herokuapp.com/hello";
    const parametros = { nome: "Dear reader" };
    var $xhr = $.get(service, parametros);

    // fail service a get method
    const failService = "http://livro-capitulo07.herokuapp.com/error";
    var $xhrFail = $.get(failService);

    // cep service api and cep constant
    const cepService = "http://api.postmon.com.br/v1/cep/";
    let cep = "73025056";
    let $xhrCep = $.get(cepService + cep);

    
    
    function callService() {
        $xhr.done(function (data) {
            writeToBanner(data);
        });
        //$.get(service, parametros, function (data) {
        //    $msg.empty()
        //    $msg.text(data);
        //});
    }

    function callFailService() {
        $xhrFail.fail(function(data) {
           writeToBanner(data.responseText);
        });
    }

    // function to get value in cep input
    function onCepInputChange() {
        cep = $cep.val();
        $xhrCep = $.getJSON(cepService + cep);
    }
    // handle click and add class
    function onButtonClick() {
        
        $banner.addClass("alt");
        callService();
        callFailService();
        onCepDone(cep);
    }

    function onCepDone() {
        $xhrCep.done(function (data) {
           writeToBanner(data.logradouro);
        });
        $xhrCep.fail(function(data) {
            writeToBanner(data.statusText);
        });
    }
    // attach function to click event
    $button.click(onButtonClick);
    // attach function to change event
    $cep.change(onCepInputChange);

    function writeToBanner(text) {
        $msg.empty();
        $msg.text(text);
    }
    //$button.on("click", function () {
    //    $banner.addClass("alt")
    //    callService()
    //})

 
    //const characters = [
    //    { id: 1, name: 'ironman' },
    //    { id: 2, name: 'black_widow' },
    //    { id: 3, name: 'captain_america' },
    //    { id: 4, name: 'captain_america' },
    //];

    //function getCharacter(name) {
    //    return character => character.name === name;
    //}

    //console.log(characters.filter(getCharacter('captain_america')));
    //console.log(characters.find(getCharacter('captain_america')));
    //console.log(characters.some(getCharacter('captain_america')));
  
})
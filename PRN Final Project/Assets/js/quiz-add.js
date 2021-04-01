function getAddField(index) {
    return `<div class="row quiz-add-item">
    <div class="row quiz-add-item-control">
        <div class="col-sm-12 col-md-6 quiz-item-count">
            <h3>${index}</h3>
        </div>
        <div class="col-sm-12 col-md-6 quiz-item-delete">
            <button disabled title="Xóa thuật ngữ"><i class="fas fa-trash-alt"></i></button>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12 col-md-6 quiz-add-input-field">
            <input type="text" name="" placeholder="" value="">
            <label for="">Thuật ngữ</label>
        </div>
        <div class="col-sm-12 col-md-6 quiz-add-input-field">
            <input type="text" name="" placeholder="" value="">
            <label for="">Định nghĩa</label>
        </div>
    </div>

</div>`
}

/**
 * @function getAddField get a add field template by index, term and define
 * @param index index of quiz 
 * @param term term of quiz
 * @param definition definention
 */
function getAddField(index, term, definition) {
    return `<div class="row quiz-add-item">
    <div class="row quiz-add-item-control">
        <div class="col-sm-12 col-md-6 quiz-item-count">
            <h3>${index}</h3>
        </div>
        <div class="col-sm-12 col-md-6 quiz-item-delete">
            <button disabled title="Xóa thuật ngữ"><i class="fas fa-trash-alt"></i></button>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12 col-md-6 quiz-add-input-field">
            <input type="text" name="" placeholder="" value="${term}">
            <label for="">Thuật ngữ</label>
        </div>
        <div class="col-sm-12 col-md-6 quiz-add-input-field">
            <input type="text" name="" placeholder="" value="${definition}">
            <label for="">Định nghĩa</label>
        </div>
    </div>

</div>`
}


function viewDemo() {
    let text = $("#quiz-add-textarea").text();

    let cardDevide = $("#quiz-devide-card").text();

    let teDevide = $("#quiz-devide-te-de").text();

    cardDevide = cardDevide ? "\n" : cardDevide;

    teDevide = teDevide ? "|" : teDevide;

    //quiz-add-container-demo

    if (text == "") {
        $("#quiz-add-container-demo").html(`<h3 style="text-align: center;">Không có thẻ nào để xem trước</h3>`);
    } else {
        let card = text.split(cardDevide);
        card.forEach((el, index) => {
            let te_de = el.split(teDevide);

            if(te_de > 1){
                $("#quiz-add-container-demo").append(getAddField(index + 1, te_de[0], te_de.slice(1, te_de.length).join(teDevide)));
            }else{
                $("#quiz-add-container-demo").append(getAddField(index + 1, te_de[0], ""));
            }
        })
    }

    console.log("hi");

}

$(document).ready(() => {


    $("#quiz-add-item-button").click((e) => {
        let amount = document.getElementsByClassName("quiz-add-item").length + 1;
        $("#term-amount").text(amount);
        $("#quiz-add-container").append(getAddField(amount, "", ""));
    })
})
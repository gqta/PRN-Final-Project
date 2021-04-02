// this function return a html presentation for a quiz
/*
*  @param index index for question
*  @param questionId Id of question
*  @param question question
*  @param answes answers of question. It is an array
* @return a html element 
*/
function getQuestion(index, questionId, question, answers) {
    return `<div class="row quiz-term-test item_${questionId}">
    <div class="col-sm-12 quiz-test-question">
        <h4><span>Q${index}.</span><span>${question}</span></h4>
    </div>
    ${answers.map(el => {
        return `<div class="row">
        <div class="col-sm-1 quiz-test-radiobox">
            <input type="radio" name="item_${questionId}" value="${el}">
        </div>
        <div class="col-sm-11"><label>${el}</label></div>
        </div>`;
    }).join("\n")}
</div>`
}

/**
 * get quiz list by using key as key as question and values as answers
 * @param {*} terms is a aarray contain quiz
 */
function getQuestionByKey(terms) {
    let answers = [];

    // get unique definition 
    terms.forEach(el => {
        if (answers.indexOf(el.definition) == -1) {
            answers.push(el.definition)
        }
    });
    let quizs = terms.map((el) => {

        let numberOfAnswers = answers.length >= 4 ? 3 : answers.length - 1;

        let quizAnswers = [el.definition];

        for (let i = 0; i < numberOfAnswers;) {

            let answer = answers[Math.round(Math.random() * (answers.length - 1))]; // lấy ra 1 đáp án ngẫu nhiên của phần từ answers list

            if (quizAnswers.indexOf(answer) == -1) {
                if (Math.round(Math.random)) {
                    quizAnswers.push(answer);
                } else {
                    quizAnswers.unshift(answer);
                }
                i++;
            }
        }
        return {
            "quizId": el.termID,
            "question": el.key,
            "answers": quizAnswers,
        };
    })

    return quizs;

}

/**
 * 
 * @param {*} terms 
 * @returns 
 */
function getQuestionByDefinition(terms) {
    let answers = [];

    // get unique definition 
    terms.forEach(el => {
        if (answers.indexOf(el.key) == -1) {
            answers.push(el.key)
        }
    });
    let quizs = terms.map((el) => {

        let numberOfAnswers = answers.length >= 4 ? 3 : answers.length - 1;

        let quizAnswers = [el.key];

        for (let i = 0; i < numberOfAnswers;) {

            let answer = answers[Math.round(Math.random() * (answers.length - 1))]; // lấy ra 1 đáp án ngẫu nhiên của phần từ answers list

            if (quizAnswers.indexOf(answer) == -1) {
                if (Math.round(Math.random)) {
                    quizAnswers.push(answer);
                } else {
                    quizAnswers.unshift(answer);
                }
                i++;
            }
        }
        return {
            "quizId": el.termID,
            "question": el.definition,
            "answers": quizAnswers,
        };
    })

    return quizs;

}

function getRandomTermsByNumber(terms, amount) {
    if (amount >= terms.length) {
        return terms;
    } else {
        let termList = [];

        for (let i = 0; i < terms.length; i++) {
            termList.splice(Math.round(Math.random() * i), 0, terms[i]);
        }
        return termList.slice(0, amount);
    }
}

$(document).ready(() => {

    const terms = [{ "termID": 4, "key": "Hòa Lạc", "definition": "Bún bò ngon nhất là ở đâu ?" }, { "termID": 5, "key": "Thanh Hóa", "definition": "Nem chua có xuất sứ ở đâu ?" }, { "termID": 6, "key": "Vũng Tàu", "definition": "Nơi nào sau đây ở Việt Nam có vùng biển được bình chọn là đẹp nhất năm 2018 ?" }, { "termID": 7, "key": "Hà Nội", "definition": "Đâu là thử đô của Việt Nam ?" }, { "termID": 74, "key": "Sóc Trăng", "definition": "Bánh Pía là đặc sản của tỉnh nào sau đây?" }, { "termID": 76, "key": "Đà Lạt", "definition": "Bánh tráng nướng là món ăn nổi tiếng nhất ở địa phương nào?" }, { "termID": 77, "key": "Lẩu mắm", "definition": "U Minh nổi tiếng với món đặc sản nào sau đây? " }, { "termID": 78, "key": "Vũng Tàu", "definition": "Bánh khọt là đặc sản của tỉnh:" }, { "termID": 79, "key": "Đồng Tháp", "definition": "Các món ăn về chuột đồng không thể bỏ lỡ khi bạn đến với tỉnh thành nào? " }, { "termID": 80, "key": "Gỏi lá sầu đâu", "definition": "Châu Đốc, An Giang nổi tiếng với món gỏi nào sao đây?" }, { "termID": 81, "key": "Bình Thuận", "definition": "Món bánh xèo là đặc sản nổi tiếng của địa phương nào dưới đây?" }, { "termID": 83, "key": "Nha Trang", "definition": "Bạn có thể tìm thấy món bún sứa thơm ngon ở vùng nào sau đây?" }, { "termID": 84, "key": "Đắk Nông", "definition": "Cá lăng nướng than là món ăn đặc trưng của vùng nào sau đây?" }, { "termID": 85, "key": "Bún chả cá", "definition": "Nói đến Đà Nẵng thì đặc sản đầu tiên phải kể đến đó chính là:" }, { "termID": 86, "key": "Bánh đa cua", "definition": " Nhắn đến đặc sản đất cảng Hải Phòng, không thể không kể đến món nào dưới đây? " }, { "termID": 87, "key": "Nam Định", "definition": "Bún đũa là đặc sản của tỉnh:" }, { "termID": 88, "key": "Ninh Bình", "definition": "Cơm cháy là đặc sản nổi tiếng của vùng địa phương nào dưới đây?" }, { "termID": 89, "key": " Bánh bèo", "definition": "Tên gọi của món đặc sản nổi tiếng đất Huế dưới đây là:" }, { "termID": 90, "key": "Thanh Hóa", "definition": " Nem chua là đặc sản của tỉnh nào?" }, { "termID": 91, "key": "Hà Nội", "definition": "Đâu là địa danh nổi tiếng với món phở gà?" }];

    let recomendAmount = terms.length < 20 ? terms.length : 20;

    let quizs = getRandomTermsByNumber(terms, recomendAmount);

    $("#quiz-test-box").html(getQuestionByDefinition(quizs).map((el, index) => getQuestion(index + 1, el.quizId, el.question, el.answers)).join("\n"));

    $("#submit-button").click((e) => {
        let score = 0;
        terms.forEach(card => {


            let quizAnswer = [...document.getElementsByName("item_" + card["termID"])].filter(el => el.checked)[0];

            if (quizAnswer) { // contain true data
                if (card.key === quizAnswer.value || card.definition === quizAnswer.value) {
                    $(`.item_${card["termID"]}`).css("color", "green");
                    score++;
                } else {
                    $(`.item_${card["termID"]}`).css("color", "red");
                }

            } else { // not contain
                $(`.item_${card["termID"]}`).css("color", "red");

            }

            [...document.getElementsByName("item_" + card["termID"])].forEach(el => el.disabled = true);
        });
        $("#quiz-result").text(`${score * 100.0 / terms.length}%`);

    });

    $("#btn-retake-quiz").click(() => {

        // handle data here 
        // after that re-render data

        let numberOfQuiz = parseInt($("#quiz-amount-input").val());

        let quizsList = getRandomTermsByNumber(terms, numberOfQuiz);

        let isTermQuiz = document.getElementById("quiz-type-term").checked;

        if (isTermQuiz) {
            $("#quiz-test-box").html(getQuestionByDefinition(quizsList).map((el, index) => getQuestion(index + 1, el.quizId, el.question, el.answers)).join("\n"));
        } else {
            $("#quiz-test-box").html(getQuestionByKey(quizsList).map((el, index) => getQuestion(index + 1, el.quizId, el.question, el.answers)).join("\n"));
        }


    })

    const amountFeild = document.getElementById("quiz-amount-input");

    amountFeild.onkeypress = (evt) => {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        let newVal = parseInt(amountFeild.value + evt.key);
        if (charCode > 31 && (charCode < 48 || charCode > 57) || (isNaN(newVal) || newVal > terms.length || newVal <= 0))
            return false;
        return true;
    }

    document.getElementById("quiz-amount-number").innerText = terms.length;

});

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

// this function generate a quiz from a json data
/*
*  @param answes answers of question. It is an array
* @return a list of data. It is an <code>Array</code>
*/
function genQuizByTerm(quizData) {
    let allTerms = [];
    for (const id in quizData) {
        if (Object.hasOwnProperty.call(quizData, id)) {
            const element = quizData[id];

            if (allTerms.indexOf(element.term) == -1) {
                allTerms.push(element.term);
            }

        }
    }

    let quizList = []; // this will contain quiz data for each element will under format {quizId, question, answers}

    for (const id in quizData) {
        if (Object.hasOwnProperty.call(quizData, id)) {
            const element = quizData[id];

            let answerIndex = allTerms.indexOf(element.term);

            let answers = [element.term];

            let maxAnswer = allTerms.length - 1 >= 3 ? 3 : allTerms.length - 1;

            for (let i = 0; i < maxAnswer;) {
                let termId = Math.round(Math.random() * (allTerms.length - 1));
                let term = allTerms[termId];

                if (answers.indexOf(term) == -1) {
                    answers.push(term);
                    i++;
                }
            }

            if (Math.round(Math.random())) {
                quizList.push({
                    quizId: id,
                    question: element.definition,
                    answers
                });
            } else {
                quizList.unshift({
                    quizId: id,
                    question: element.definition,
                    answers
                });
            }



        }
    }

    return quizList;
}

// this function generate a quiz from a json data
/*
*  @param answes answers of question. It is an array
* @return a list of data. It is an <code>Array</code>
*/
function genQuizByDefinition(quizData) {
    let allDefinitions = [];
    for (const id in quizData) {
        if (Object.hasOwnProperty.call(quizData, id)) {
            const element = quizData[id];

            if (allDefinitions.indexOf(element.definition) == -1) {
                allDefinitions.push(element.definition);
            }

        }
    }

    let quizList = []; // this will contain quiz data for each element will under format {quizId, question, answers}

    for (const id in quizData) {
        if (Object.hasOwnProperty.call(quizData, id)) {
            const element = quizData[id];

            let answerIndex = allDefinitions.indexOf(element.definition);

            let answers = [element.definition];

            let maxAnswer = allDefinitions.length - 1 >= 3 ? 3 : allDefinitions.length - 1;

            for (let i = 0; i < maxAnswer;) {
                let termId = Math.round(Math.random() * (allDefinitions.length - 1));
                let term = allDefinitions[termId];

                if (answers.indexOf(term) == -1) {
                    answers.push(term);
                    i++;
                }
            }

            if (Math.round(Math.random())) {
                quizList.push({
                    quizId: id,
                    question: element.term,
                    answers
                });
            } else {
                quizList.unshift({
                    quizId: id,
                    question: element.term,
                    answers
                });
            }
            

        }
    }

    return quizList;
}



$(document).ready(() => {
    "use strict";

    const amount = 4;
    const quizData = {
        "111": {
            term: "Thanh Hóa",
            definition: "Nem chua là đặc sản của khu vực nào?"
        },
        "112": {
            term: "Hà Nội",
            definition: "Đâu là thủ đo của nước việt nam?"
        },
        "113": {
            term: "Hải Dương",
            definition: "Đâu là quê hương của bánh đậu xanh?"
        },
        "114": {
            term: "Hòa Lạc",
            definition: "Bún Bò nào là ngon nhất?"
        }
    };

    // 

    $("#quiz-test-box").html(genQuizByTerm(quizData).map((el, index) => getQuestion(index + 1, el.quizId, el.question, el.answers)).join("\n"));

    $("#btn-retake-quiz").click(() => {

        // handle data here 
        // after that re-render data

        let numberOfQuix = parseInt($("#quiz-amount-input").val());

        let isTermQuiz = document.getElementById("quiz-type-term").checked;

        if (isTermQuiz) {
            $("#quiz-test-box").html(genQuizByTerm(quizData).map((el, index) => getQuestion(index + 1, el.quizId, el.question, el.answers)).join("\n"));
        } else {
            $("#quiz-test-box").html(genQuizByDefinition(quizData).map((el, index) => getQuestion(index + 1, el.quizId, el.question, el.answers)).join("\n"));
        }


    })

    $("#submit-button").click((e) => {

        let score = 0;
        for (const quizId in quizData) {
            if (Object.hasOwnProperty.call(quizData, quizId)) {


                const element = quizData[quizId];

                let quizAnswer = [...document.getElementsByName("item_" + quizId)].filter(el => el.checked)[0];

                if (quizAnswer) { // contain true data
                    if (element.term === quizAnswer.value || element.definition === quizAnswer.value) {
                        $(`.item_${quizId}`).css("color", "green");
                        score++;
                    } else {
                        $(`.item_${quizId}`).css("color", "red");
                    }

                } else { // not contain
                    $(`.item_${quizId}`).css("color", "red");

                }

                [...document.getElementsByName("item_" + quizId)].forEach(el => el.disabled = true);

            }
        }
        $("#quiz-result").text(`${score * 100.0 / amount}%`);
    });


    //------ handle amount field---------

    const amountFeild = document.getElementById("quiz-amount-input");

    amountFeild.onkeypress = (evt) => {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        let newVal = parseInt(amountFeild.value + evt.key);
        if (charCode > 31 && (charCode < 48 || charCode > 57) || (isNaN(newVal) || newVal > amount || newVal <= 0))
            return false;
        return true;
    }

    document.getElementById("quiz-amount-number").innerText = amount;
});





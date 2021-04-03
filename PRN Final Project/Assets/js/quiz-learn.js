let quiz = [];

let current = 0;
let resetAPI = "";
let SetAPI = "";

let quizList = getQuestionByKey(quiz);
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
function genQuiz(quiz) {
    let lable = "ABCD";
    return `<div class="question-box">
    <div class="quiz-question-box">
        <input type="hidden" class="" id="quiz-id" value="${quiz.quizId}">
        
        ${quiz.question}
    </div>
    <div class="quiz-answer-box">
        
        ${quiz.answers.map((el, index) => {
        return `<div class="quiz-answer-button" onclick="answer(this)"><span class="quiz-answer-lable">${lable[index]}</span>
            <p class="quiz-answer-content">${el}</p>
        </div>`
    }).join("\n")}
    </div>
</div>`
}

function answer(el) {
    let result = el.getElementsByClassName("quiz-answer-content")[0].innerText;

    let isTrue = quiz[current].key.toLocaleLowerCase().trim() == result.toLocaleLowerCase().trim()
        || quiz[current].definition.toLocaleLowerCase().trim() == result.toLocaleLowerCase().trim();

    if (isTrue) {
        $("#quiz-modal-result").text("Đúng rùi nè!");
        $("#quiz-modal-result").css("background", "green");
        $("#quiz-modal-result").css("color", "white");

        $.get(SetAPI + "/" + (current + 1), (data) => {
            console.log(data)
            if (data && data.progress != undefined) {
                current = data.progress;
            } else {
                localStorage.setItem("current", current + 1);
            }
        })

        if (current + 1 == terms.length) {
            $("#question-box").html(`<h1>Chúc mừng bạn đã học xong <br> Làm thêm nháy nữa cho nắm chắc</h1>`);
        } else {
            $("#question-box").html(genQuiz(quizList[++current % quizList.length]));
        }

    } else {
        $("#quiz-modal-result").text("Sai rồi bạn tôi ơi! đọc kĩ lại chút nào!");
        $("#quiz-modal-result").css("background", "red");
        $("#quiz-modal-result").css("color", "white");
    }

    $("#quiz-result").text(`${current * 100.0 / quiz.length}%`)


    $("#result").show();

    setTimeout(() => {
        $("#result").hide();
    }, 2000);
}










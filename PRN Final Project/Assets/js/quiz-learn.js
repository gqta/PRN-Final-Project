const quiz = {
    amount: 4,
    data: {
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
    }
};

let current = 0;

let quizList = genQuizByDefinition(quiz.data);

/**
 * 
 * @param {*} quizData 
 * @returns a array of quiz by format 
 *          {
                quizId: id,
                question: definition,
                answers : array of term
            }
 */
function genQuizByDefinition(quizData) {
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

/**
 * 
 * @param {*} quizData 
 * @returns  a array of quiz by format 
 *          {
                quizId: id,
                question: a term,
                answers: array of definition
            }
 */
function genQuizByTerm(quizData) {
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

function answer(el){
    let result = el.getElementsByClassName("quiz-answer-content")[0].innerText;
            let quizID = $("#quiz-id").val();

            if (quiz.data[quizID].term.toLocaleLowerCase() == result.toLocaleLowerCase()) {
                $("#quiz-modal-result").text("Đúng rùi nè!");
                $("#quiz-modal-result").css("background", "green");
                $("#quiz-modal-result").css("color", "white");
                $("#question-box").html(genQuiz(quizList[++current%quizList.length]));
            } else {
                $("#quiz-modal-result").text("Sai rồi bạn tôi ơi! đọc kĩ lại chút nào!");
                $("#quiz-modal-result").css("background", "red");
                $("#quiz-modal-result").css("color", "white");
            }


            $("#result").show();

            setTimeout(() => {
                $("#result").hide();
            }, 2000);
}


$(document).ready(() => {
    "use strict";

    $("#question-box").html(genQuiz(quizList[current]));

    
    $("#btn-retake-quiz").click(()=>{
        
    });

});





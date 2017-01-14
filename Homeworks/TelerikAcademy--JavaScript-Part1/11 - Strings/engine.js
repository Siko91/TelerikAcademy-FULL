
function ShowResult(result, resultDivClass, taskNumber)
{
    document.getElementById("result" + taskNumber).className = resultDivClass;
    document.getElementById("result" + taskNumber).innerHTML = result;
}

function ThrowError(taskNumber)
{
	ShowResult("Error", "error", taskNumber);
}

function HandleClicks(taskNumber)
{
    switch (taskNumber) {
        case 1: DoTask1(); break;
        case 2: DoTask2(); break;
        case 3: DoTask3(); break;
        case 4: DoTask4(); break;
        case 5: DoTask5(); break;
        case 6: DoTask6(); break;
        case 7: DoTask7(); break;
        case 8: DoTask8(); break;
        case 9: DoTask9(); break;
        case 10: DoTask10(); break;
        case 11: DoTask11(); break;
        case 12: DoTask12(); break;
        default: break;
    }
}
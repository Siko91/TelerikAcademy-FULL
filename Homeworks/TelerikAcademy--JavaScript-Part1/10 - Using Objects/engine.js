
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
        default: break;
    }
}
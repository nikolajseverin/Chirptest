List<int> scores = [1,2,3,4,5,6,7,8,9,10]

//løsning 1
foreach (var score in scores) {
    if (score > 5)
    {
            Console.Write(i + " ")

    }
}

//løsning 2
IEnumerable<int> scoreqeury =
    from scoreqeury in scores
    where score > 5
    select score

foreach (var i in scoreqeury)
{
    Console.Write(i + " ")
}
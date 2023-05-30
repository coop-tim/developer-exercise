using Microsoft.AspNetCore.Mvc;

namespace Coop.Interview.Api.Http.Controllers;

[ApiController]
[Route("game")]
public class GameController : Controller
{
    List<string> actions = new List<string>();

    [HttpPost]
    [Route("play")]
    public string Play(PlayRequest request)
    {
        actions.Add("rock");
        actions.Add("paper");
        actions.Add("scissors");

        string action = actions.OrderBy(a => new Random().Next()).First();

        if (action == request.Action)
        {
            return "I play " + action + ". It's a draw!";
        }

        if (action == "rock" && request.Action == "paper")
        {
            return "I play " + action + ". Winner!";
        }
        if (action == "rock" && request.Action == "scissors")
        {
            return "I play " + action + ". Loser!";
        }
        if (action == "paper" && request.Action == "scissors")
        {
            return "I play " + action + ". Winner!";
        }
        if (action == "paper" && request.Action == "rock")
        {
            return "I play " + action + ". Loser!";
        }
        if (action == "scissors" && request.Action == "paper")
        {
            return "I play " + action + ". Loser!";
        }
        if (action == "scissors" && request.Action == "rock")
        {
            return "I play " + action + ". Winner!";
        }

        return "You have to play rock, paper or scissors";
    }

    [HttpPost]
    [Route("playmultiple")]
    public string[] PlayMultiple(MultiplePlayRequest request)
    {
        actions.Add("rock");
        actions.Add("paper");
        actions.Add("scissors");

        string action = actions.OrderBy(a => new Random().Next()).First();

        List<string> results = new List<string>();
        foreach(string player in request.Actions)
        {
            if (action == player)
            {
                results.Add("I play " + action + ". It's a draw!");
            }

            if (action == "rock" && player == "paper")
            {
                results.Add("I play " + action + ". Winner!");
            }
            if (action == "rock" && player == "scissors")
            {
                results.Add("I play " + action + ". Loser!");
            }
            if (action == "paper" && player == "scissors")
            {
                results.Add("I play " + action + ". Winner!");
            }
            if (action == "paper" && player == "rock")
            {
                results.Add("I play " + action + ". Loser!");
            }
            if (action == "scissors" && player == "paper")
            {
                results.Add("I play " + action + ". Loser!");
            }
            if (action == "scissors" && player == "rock")
            {
                results.Add("I play " + action + ". Winner!");
            }

            results.Add("You have to play rock, paper or scissors");
        }

        return results.ToArray();
    }
}

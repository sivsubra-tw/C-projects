using NUnit.Framework;
using Game;

namespace Game.Tests;
[TestFixture]
public class RockPaperScissors_DeclareWinner
{
    private RockPaperScissors _rockPaperScissors;

    [SetUp]
    public void Setup()
    {
        _rockPaperScissors = new RockPaperScissors();
    }

    [Test]
    public void RockPaperScissors_InputAreRockAndScissors_DeclareWinner()
    {
        Assert.That(_rockPaperScissors.DeclareWinner(Input.ROCK, Input.SCISSORS), Is.EqualTo(Input.ROCK));
    }

    [Test]
    public void RockPaperScissors_InputAreRockAndPaper_DeclareWinner()
    {
        Assert.That(_rockPaperScissors.DeclareWinner(Input.ROCK, Input.PAPER), Is.EqualTo(Input.PAPER));
    }

    [Test]
    public void RockPaperScissors_InputArePaperAndScissors_DeclareWinner()
    {
        Assert.That(_rockPaperScissors.DeclareWinner(Input.PAPER, Input.SCISSORS), Is.EqualTo(Input.SCISSORS));
    }

    [Test]
    public void RockPaperScissors_InputAreTheSame_DeclareWinner()
    {
        Assert.That(_rockPaperScissors.DeclareWinner(Input.ROCK, Input.ROCK), Is.EqualTo(Input.ROCK));
    }
}
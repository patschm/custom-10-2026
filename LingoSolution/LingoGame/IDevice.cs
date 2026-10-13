
namespace LingoGame;

public interface IDevice
{
    void TekenIncorrect(char c);
    void TekenCorrect(char c);
    void TekenWrongPosition(char c);

}

using System;

namespace csharp_lox
{
  public class Token
  {
    private readonly TokenType _type;
    private readonly string _lexeme;
    private readonly object _literal;
    private readonly int _line;

    public Token(TokenType type, string lexeme, object literal, int line)
    {
      this._type = type;
      this._lexeme = lexeme;
      this._literal = literal;
      this._line = line;
    }

    public override string ToString()
    {
      return _type + " " + _lexeme + " " + _literal;
    }
  }
}
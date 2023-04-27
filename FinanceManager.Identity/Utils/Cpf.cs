public struct Cpf
{
    private readonly string _value;

    public readonly bool Isvalid;

    private Cpf(string value)
    {
        _value = value;

        if (value == null)
        {
            Isvalid = false;
            return;
        }

        var position = 0;
        var totalDigit1 = 0;
        var totalDigit2 = 0;
        var dv1 = 0;
        var dv2 = 0;

        var sameDigits = true;
        var lastDigit = -1;

        foreach (var c in value)
        {
            if (char.IsDigit(c))
            {
                var digit = c - '0';
                if (position != 0 && lastDigit != digit)
                {
                    sameDigits = false;
                }

                lastDigit = digit;
                if (position < 9)
                {
                    totalDigit1 += digit * (10 - position);
                    totalDigit2 += digit * (11 - position);
                }
                else if (position == 9)
                {
                    dv1 = digit;
                }
                else if (position == 10)
                {
                    dv2 = digit;
                }

                position++;

            }
        }

        if (position > 11)
        {
            Isvalid = false;
            return;
        }

        if (sameDigits)
        {
            Isvalid = false;
            return;
        }

        var digito1 = totalDigit1 % 11;
        digito1 = digito1 < 2
            ? 0
            : 11 - digito1;

        if (dv1 != digito1)
        {
            Isvalid = false;
            return;
        }

        totalDigit2 += digito1 * 2;
        var digito2 = totalDigit2 % 11;
        digito2 = digito2 < 2
            ? 0
            : 11 - digito2;

        Isvalid = dv2 == digito2;
    }

    public static implicit operator Cpf(string value)
        => new Cpf(value);

    public override string ToString() => _value;

    /// <summary>
    /// Retorna um booleano indicando se o Cpf é válido ou não
    /// </summary>
    /// <param name="sourceCPF"></param>
    /// <returns></returns>
    public static bool IsValid(Cpf sourceCPF) =>

        sourceCPF.Isvalid;

    /// <summary>
    /// Converte o tipo (struct)Cpf para string
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Cpf Parse(string value)
    {
        return new Cpf(value);
    }

    public string FormatedCpf => Convert.ToInt64(_value).ToString(@"000\.000\.000\-00");
}
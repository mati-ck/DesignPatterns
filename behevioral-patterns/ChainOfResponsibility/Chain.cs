namespace ChainOfResponsibility;

public class Chain
{
    private readonly Handler _chain;

    public Chain()
    {
        _chain = BuildChain();
    }

    private Handler BuildChain()
    {
        return new NegativeHandler(new ZeroHandler(new PositiveHandler(null)));
    }

    public void HandleRequest(Number request)
    {
        _chain.HandleRequest(request);
    }
}

abstract class Handler
{
    private readonly Handler? _handler;

    protected Handler(Handler? handler)
    {
        _handler = handler;
    }

    public virtual void HandleRequest(Number request)
    {
        if (_handler != null)
            _handler.HandleRequest(request);
    }
}

public class Number
{
    private readonly int _number;

    public Number(int number)
    {
        _number = number;
    }

    public int GetNumber()
    {
        return _number;
    }
}

class NegativeHandler : Handler
{
    public NegativeHandler(Handler? handler) : base(handler)
    {
    }

    public override void HandleRequest(Number request)
    {
        if (request.GetNumber() < 0)
        {
            Console.WriteLine("NegativeProcessor : " + request.GetNumber());
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}

class ZeroHandler : Handler
{
    public ZeroHandler(Handler? handler) : base(handler)
    {
    }

    public override void HandleRequest(Number request)
    {
        if (request.GetNumber() == 0)
        {
            Console.WriteLine("ZeroProcessor : " + request.GetNumber());
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}

class PositiveHandler : Handler
{
    public PositiveHandler(Handler? handler) : base(handler)
    {
    }

    public override void HandleRequest(Number request)
    {
        if (request.GetNumber() > 0)
        {
            Console.WriteLine("PositiveProcessor : " + request.GetNumber());
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}
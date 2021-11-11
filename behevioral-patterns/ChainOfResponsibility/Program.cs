// See https://aka.ms/new-console-template for more information

using ChainOfResponsibility;

Chain chain = new Chain();

chain.HandleRequest(new Number(90));
chain.HandleRequest(new Number(-50));
chain.HandleRequest(new Number(0));
chain.HandleRequest(new Number(91));

Console.ReadKey(); 
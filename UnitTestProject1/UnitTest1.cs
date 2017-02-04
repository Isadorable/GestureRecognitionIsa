﻿using System;
// Test
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Djestit
using RecognitionGestureFeed_Universal.Djestit;
using System.Collections.Generic;
// Debug
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //    [TestMethod]
        //    public void Composition()
        //    {
        //        GroundTerm term1 = new GroundTerm();
        //        GroundTerm term2 = new GroundTerm();
        //        GroundTerm term3 = new GroundTerm();
        //        GroundTerm term4 = new GroundTerm();

        //        List<Term> lista1 = new List<Term>();
        //        lista1.Add(term1);
        //        lista1.Add(term2);
        //        List<Term> lista2 = new List<Term>();
        //        lista2.Add(term3);
        //        lista2.Add(term4);
        //        Sequence sequence = new Sequence(lista1);
        //        Parallel parallel = new Parallel(lista2);

        //        Assert.IsTrue( sequence.children != parallel.children , "Passed");
        //    }

        //    [TestMethod]
        //    public void IterativeOperator()
        //    {

        //        GroundTerm term1 = new GroundTerm();
        //        Iterative iterative = new Iterative(term1);

        //        Token token1 = new Token();
        //        iterative.fire(token1);
        //        Assert.IsTrue(expressionState.Complete == iterative.state, "First iteration completed");

        //        Token token2 = new Token();
        //        iterative.fire(token2);
        //        Assert.IsTrue(expressionState.Complete == iterative.state, "Second iteration completed");
        //    }

        //    [TestMethod]
        //    public void SequenceOperator()
        //    {
        //        GroundTerm term1 = new GroundTerm();
        //        GroundTerm term2 = new GroundTerm();

        //        List<Term> lista1 = new List<Term>();
        //        lista1.Add(term1);
        //        lista1.Add(term2);

        //        Sequence sequence = new Sequence(lista1);
        //        sequence.Complete += onComplete1;

        //        sequence.fire(new Token());
        //        sequence.fire(new Token());

        //        Assert.IsTrue(expressionState.Complete == sequence.state, "Sequence completed");


        //        sequence.fire(new Token());
        //        Assert.IsTrue(expressionState.Error == sequence.state, "No more token accepted");
        //    }


        //    [TestMethod]
        //    public void IterativeOperator2()
        //    {
        //        GroundTerm term1 = new GroundTerm();
        //        Iterative iterative = new Iterative(term1);

        //        iterative.Complete += onComplete2;

        //        iterative.fire(new Token());
        //        iterative.fire(new Token());

        //    }

        //    [TestMethod]
        //    public void ParallelOperator()
        //    {

        //        GroundTerm term1 = new GroundTerm();
        //        GroundTerm term2 = new GroundTerm();
        //        List<Term> lista = new List<Term>();
        //        lista.Add(term1);
        //        lista.Add(term2);

        //        Parallel parallel = new Parallel(lista);

        //        //parallel.Complete += onComplete2;
        //        GestureEventArgs t1 = new GestureEventArgs(term1);
        //        term1.onComplete(t1);

        //        //parallel.Complete += onComplete2;
        //        GestureEventArgs t2 = new GestureEventArgs(term2);
        //        term2.onComplete(t2);

        //        parallel.fire(new Token());
        //        Assert.IsTrue(expressionState.Complete == parallel.state, "Passed!");

        //    }

        //    [TestMethod]
        //    public void ParallelOperator1()
        //    {
        //        GroundTerm term1 = new GroundTerm();
        //        term1.accepts = acceptsA;
        //        GroundTerm term2 = new GroundTerm();
        //        term2.accepts = acceptsB;
        //        Iterative iterative1 = new Iterative(term1);
        //        Iterative iterative2 = new Iterative(term1);
        //        List<Term> listTerm = new List<Term>();
        //        listTerm.Add(iterative1);
        //        listTerm.Add(iterative2);

        //        term1.Complete += onComplete2;
        //        term2.Complete += onComplete2;

        //        Parallel parallel = new Parallel(listTerm);
        //        Token tokenA = new Token();
        //        tokenA.type = "A";
        //        Token tokenB = new Token();
        //        tokenB.type = "B";

        //        parallel.fire(tokenA);
        //        parallel.fire(tokenA);
        //        parallel.fire(tokenB);

        //        Assert.IsTrue(expressionState.Complete == parallel.state, "Passed!");

        //    }

        //    [TestMethod]
        //    public void ChoiceOperator()
        //    {
        //       GroundTerm term1 = new GroundTerm();
        //       term1.accepts = acceptsA;
        //       GroundTerm term2 = new GroundTerm();
        //       GroundTerm term3 = new GroundTerm();
        //       term3.accepts = acceptsB;
        //       GroundTerm term4 = new GroundTerm();
        //       term4.accepts = acceptsB;

        //       List<Term> listTerm1 = new List<Term>();
        //       List<Term> listTerm2 = new List<Term>();
        //       listTerm1.Add(term1);
        //       listTerm1.Add(term2);
        //       listTerm2.Add(term3);
        //       listTerm2.Add(term4);

        //       Sequence sequence = new Sequence(listTerm1);
        //       Parallel parallel = new Parallel(listTerm2);

        //       List<Term> listTerm3 = new List<Term>();
        //       listTerm3.Add(sequence);
        //       listTerm3.Add(parallel);
        //       Choice choice = new Choice(listTerm3);
        //       Token tokenA = new Token();
        //       tokenA.type = "A";
        //       Token tokenB = new Token();
        //       tokenB.type = "B";

        //       choice.fire(tokenA);
        //       choice.fire(tokenA);

        //       Assert.IsTrue(sequence.state == expressionState.Complete, "First operand (sequence) completed");
        //       Assert.IsTrue(choice.state == expressionState.Complete, "Choice completed");

        //       choice.reset();
        //       choice.fire(tokenB);
        //       Assert.IsTrue(parallel.state == expressionState.Complete, "Second operand (parallel) completed");
        //       Assert.IsTrue(choice.state == expressionState.Complete, "Choice completed");
        //    }


        //    [TestMethod]
        //    public void OrderIndependenceOperator()
        //    {
        //        GroundTerm term1 = new GroundTerm();
        //        term1.accepts = acceptsA;
        //        GroundTerm term2 = new GroundTerm();
        //        GroundTerm term3 = new GroundTerm();
        //        term3.accepts = acceptsB;
        //        GroundTerm term4 = new GroundTerm();
        //        term4.accepts = acceptsA;

        //        List<Term> listTerm1 = new List<Term>();
        //        List<Term> listTerm2 = new List<Term>();
        //        listTerm1.Add(term1);
        //        listTerm1.Add(term2);
        //        listTerm2.Add(term3);
        //        listTerm2.Add(term4);

        //        Sequence sequence = new Sequence(listTerm1);
        //        Parallel parallel = new Parallel(listTerm2);



        //        List<Term> listTerm3 = new List<Term>();
        //        listTerm3.Add(sequence);
        //        listTerm3.Add(parallel);
        //        OrderIndependece order = new OrderIndependece(listTerm3);

        //        Token tokenA = new Token();
        //        tokenA.type = "A";
        //        Token tokenB = new Token();
        //        tokenB.type = "B";

        //        order.fire(tokenA);
        //        order.fire(tokenA);

        //        Assert.IsTrue(sequence.state == expressionState.Complete, "First operand (sequence) completed 1");

        //        order.fire(tokenB);
        //        order.fire(tokenA);

        //        Assert.IsTrue(parallel.state == expressionState.Complete, "Second operand (parallel) completed 1");
        //        Assert.IsTrue(order.state == expressionState.Complete, "OrderIndependence completed 1");

        //        order.reset();

        //        order.fire(tokenB);
        //        order.fire(tokenA);

        //        Assert.IsTrue(parallel.state == expressionState.Complete, "Second operand (parallel) completed 2");

        //        order.fire(tokenA);
        //        order.fire(tokenA);

        //    Assert.IsTrue(sequence.state == expressionState.Complete, "First operand (sequence) completed 2");
        //    Assert.IsTrue(order.state == expressionState.Complete, "OrderIndependence completed 2");
        //}

        //[TestMethod]
        //public void DisablingOperator()
        //    {
        //        GroundTerm term1 = new GroundTerm();
        //        term1.accepts = acceptsA;
        //        Iterative iterative1 = new Iterative(term1);
        //        GroundTerm term2 = new GroundTerm();
        //        term2.accepts = acceptsB;
        //        Iterative iterative2 = new Iterative(term2);
        //        GroundTerm term3 = new GroundTerm();
        //        term3.accepts = acceptsC;

        //        List<Term> listTerm = new List<Term>();
        //        listTerm.Add(iterative1);
        //        listTerm.Add(iterative2);
        //        listTerm.Add(term3);
        //        Disabling disabling = new Disabling(listTerm);

        //        Token tokenA = new Token();
        //        tokenA.type = "A";
        //        Token tokenB = new Token();
        //        tokenB.type = "B";
        //        Token tokenC = new Token();
        //        tokenC.type = "C";

        //        // a sequence of A tokens
        //        disabling.fire(tokenA);
        //        disabling.fire(tokenA);

        //        // send a C token
        //        disabling.fire(tokenC);


        //        Assert.IsTrue(disabling.state == expressionState.Complete, "C token accepted 1");

        //        disabling.reset();

        //        disabling.fire(tokenA);
        //        disabling.fire(tokenB);
        //        disabling.fire(tokenA);

        //        Assert.IsTrue(disabling.state == expressionState.Error, "A token after B not accepted");

        //        disabling.reset();

        //        // a sequence of A tokens
        //        disabling.fire(tokenA);
        //        disabling.fire(tokenA);
        //        disabling.fire(tokenA);
        //        disabling.fire(tokenA);

        //        // stop with a B token
        //        disabling.fire(tokenB);
        //        Assert.IsTrue(iterative2.state == expressionState.Complete, "B tokens accepted");

        //        disabling.fire(tokenC);
        //        Assert.IsTrue(disabling.state == expressionState.Complete, "C tokens accepted 2");
        //    }

        //#region metodi & classi
        ////metodi
        //    public bool accepts(Token token)
        //    {
        //        return token.type != null && token.type == "A";
        //    }
        //    public bool _accepts(Token token)
        //    {
        //        return token.type != null && token.type == "B";
        //    }

        //    // Funzioni per OnComplete
        //    private void onComplete1(object sender, GestureEventArgs t)
        //    {
        //        Debug.Assert(true, "stato: " +t.t.state);
        //    }

        //    private void onComplete2(object sender, GestureEventArgs t)
        //    {
        //        Assert.IsTrue(expressionState.Complete == t.t.state, "Sequence completed");
        //    }

        //    // Accepts
        //    internal bool acceptsA(Token token)
        //    {
        //        return (token.type != null && token.type == "A");
        //    }
        //    internal bool acceptsB(Token token)
        //    {
        //        return (token.type != null && token.type == "B");
        //    }
        //    internal bool acceptsC(Token token)
        //    {
        //        return (token.type != null && token.type == "C");
        //    }
        //#endregion
    }
}

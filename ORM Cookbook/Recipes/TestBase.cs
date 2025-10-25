using System.Diagnostics.CodeAnalysis;

namespace Recipes;

public abstract class TestBase
{
    [SuppressMessage("Design", "CA1031")]
    protected static void AssertThrowsException(Action action)
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action), $"{nameof(action)} is null.");

        try
        {
            action();
        }
        catch (Exception ex) when (!(ex is AssertInconclusiveException) && !(ex is AssertFailedException))
        {
            return; //bypass the assert-fail on the line below
        }

        Assert.Fail("An exception was expected but not thrown.");
    }

    protected static void AssertThrowsException<TException>(Action action) where TException : Exception
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action), $"{nameof(action)} is null.");

        try
        {
            action();
        }
        catch (TException)
        {
            return; //Pass
        }
        catch (Exception ex) when (!(ex is AssertInconclusiveException) && !(ex is AssertFailedException))
        {
            Assert.Fail($"Expected a {nameof(TException)} but got a {ex.GetType().Name}.");
            return; //bypass the assert-fail on the line below
        }

        Assert.Fail("An exception was expected but not thrown.");
    }

    /*
     *  protected static async Task AssertThrowsExceptionAsync<TResult, TException>(Func<Task<TResult>> action) where TException : Exception
      {
          if (action == null)
              throw new ArgumentNullException(nameof(action), $"{nameof(action)} is null.");

          try
          {
              await action().ConfigureAwait(false);
          }
          catch (TException)
          {
              //Pass
          }
          catch (Exception ex) when (!(ex is AssertInconclusiveException) && !(ex is AssertFailedException))
          {
              Assert.Fail($"Expected a {nameof(TException)} but got a {ex.GetType().Name}.");
              return; //bypass the assert-fail on the line below
          }

          Assert.Fail("An exception was expected but not thrown.");
      }
      */

    protected static async Task AssertThrowsExceptionAsync<TException>(Func<Task> action) where TException : Exception
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action), $"{nameof(action)} is null.");

        try
        {
            await action().ConfigureAwait(false);
        }
        catch (TException)
        {
            return;//Pass
        }
        catch (Exception ex) when (!(ex is AssertInconclusiveException) && !(ex is AssertFailedException))
        {
            Assert.Fail($"Expected a {nameof(TException)} but got a {ex.GetType().Name}.");
            return; //bypass the assert-fail on the line below
        }

        Assert.Fail("An exception was expected but not thrown.");
    }

    protected void TryDispose(object repository)
    {
        (repository as IDisposable)?.Dispose();
    }
}
using Okane.Application.Expenses.Update;
using Okane.Domain;

namespace Okane.Application.Expenses;

public class InMemoryRepository : IExpensesRepository
{
    private int _nextId = 1;
    private readonly List<Expense> _expenses;

    public InMemoryRepository() => _expenses = new List<Expense>();

    public Expense Add(Expense expense)
    {
        expense.Id = _nextId++;
        _expenses.Add(expense);
        return expense;
    }

    public IEnumerable<Expense> All() => 
        _expenses;

    public Expense? ById(int id) => 
        _expenses.FirstOrDefault(expense => expense.Id == id);

    public Expense? Delete(int id)
    {
        var expense = this.ById(id);

        if (expense is null)
            return null;

        _expenses.Remove(expense);
        return expense;
    }
}
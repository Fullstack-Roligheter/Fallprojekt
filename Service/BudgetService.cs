using DAL;
using DAL.Migrations;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using Service.Interfaces;
using System.Data.SqlClient;
namespace Service
{
    public class BudgetService : IBudgetService
    {
        private readonly ProjectContext _projectContext;

        public BudgetService(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public List<BudgetNameDTO> GetBudgetsForUser(UserIdDTO user)
        {
            var budgetList = (from u in _projectContext.Users
                              join b in _projectContext.Budgets on u.Id equals b.UserId
                              where u.Id == user.UserId
                              select new BudgetNameDTO
                              {
                                  BudgetName = b.Name,
                                  BudgetId = b.Id
                              }).ToList();

            return budgetList;
        }

        public void CreateBudget(CreateBudgetDTO budget)
        {
            _projectContext.Add(new Budget
            {
                Id = Guid.NewGuid(),
                Name = budget.Name,
                StartDate = budget.StartDate,
                EndDate = budget.EndDate,
                Amount = budget.Amount,
                Comment = budget.Comment,
                UserId = budget.UserId
            });
            _projectContext.SaveChanges();
        }

        public void DeleteBudget(DeleteBudgetDTO input)
        {
            try
            {
                var result = _projectContext.Budgets.FirstOrDefault(b => b.Id == input.BudgetId);
                if (result == null) throw new NullReferenceException($"No such budget found!");

                var affectedDebits = _projectContext.Debits.Where(x => x.BudgetId == input.BudgetId).ToList();
                foreach (var debit in affectedDebits)
                {
                    debit.BudgetId = null;
                }
                _projectContext.Budgets.Remove(result);
                _projectContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void EditBudget(EditBudgetDTO editBudget)
        {
            var budget = _projectContext.Budgets.FirstOrDefault(x => x.Id == editBudget.BudgetId);
            if (budget == null)
            {
                throw new NullReferenceException($"No Budget!");
            }
            budget.Id = budget.Id;
            budget.Name = editBudget.Name;
            budget.StartDate = editBudget.StartDate;
            budget.EndDate = editBudget.EndDate;
            budget.Amount = editBudget.Amount;
            budget.Comment = editBudget.Comment;
            _projectContext.SaveChanges();
        }

        public bool BudgetIdValidation(Guid budgetId)
        {
            return _projectContext.Budgets.Any(b => b.Id == budgetId);
        }
    }
}
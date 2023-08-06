using ApartmentManagementApi.Application;
using ApartmentManagementApi.Application.Admin;
using ApartmentManagementApi.Application.User;
using ApartmentManagementApi.Application.User.CardOperations;
using ApartmentManagementApi.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi;

[ApiController]
[Route("[controller]s")]
public class CardController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public CardController(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    // Get All Cards - UserId Query den Gelmeli
    [HttpGet("{id}")]
    public ActionResult GetCardsAll(int id)
    {
        GetCards cards = new GetCards(_dbContext, _mapper);
        cards.UserId = id;
        var cardList = cards.Handle();
        return Ok(cardList);
    }

    // Create Card - UserId queryden gelmeli
    [HttpPost("{id}")]
    public IActionResult AddCard(int id,[FromBody] CreateCardViewModel model)
    {
        CreateCard card = new CreateCard(_dbContext, _mapper);
        card.model = model;
        card.UsertId = id;

        CreateCardValidator validator = new CreateCardValidator();
        validator.ValidateAndThrow(card);

        card.Handle();
        return Ok();
    }
    // Update Card
    [HttpPut("{id}")]
    public ActionResult UpdtCard(int id, [FromBody] UpdateCardViewModel updateCard)
    {
        UpdateCard card = new UpdateCard(_dbContext);
        card.CardId = id;
        card.model = updateCard;

        UpdateCardValidator validator = new UpdateCardValidator();
        validator.ValidateAndThrow(card);

        card.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCard(int id) 
    {
        DeleteCard card = new DeleteCard(_dbContext);
        card.CardId=id;

        DeleteCardValidator validator = new DeleteCardValidator();
        validator.ValidateAndThrow(card);

        card.Handle();
        return Ok();
    }
}

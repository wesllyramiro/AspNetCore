# Trilogo - Backend Developer Challenge
## Trilogo Query Language (TQL)

## Requirements

Design an API endpoint that receives filters (conditions), understands them and provides a result set based on those filters.

- the endpoint is exposed at `/tickets`
- the partial (or complete) search term is passed as a querystring parameter `tql`
- the endpoint returns a JSON response with an array of filtered tickets
    - the tickets are sorted by id
	- each ticket has id, description, current status, creation date and author
- all functional tests should pass (additional tests may be implemented as necessary)
- use the dataset provided in this test

## Trilogo Query Language

A query has 4 parts: fields, operators, values and keywords.

- Field – Fields are different types of information in the system. Trilogo fields include id, description, author, etc.
- Operator – Operators are the heart of the query. They relate the field to the value. Common operators include equals (=), not equals (!=), less than (<), etc.
- Value – Values are the actual data in the query. They are usually the item for which we are looking.
- Keyword – Keywords are specific words in the language that have special meaning. In this test we will be focused on AND only.

### Fields

A field in TQL is a word that represents a Trilogo field. In a clause, a field is followed by an operator, which in turn is followed by one or more values. The operator compares the value of the field with one or more values on the right, such that only true results are retrieved by the clause.

#### List of fields (for the matter of this test)

- id
- description
- author
- creationDate
- updated

### Operators

An operator in TQL is one or more symbols or words which compares the value of a field on its left with one or more values on its right, such that only true results are retrieved by the clause.

#### List of operators (for the matter of this test)

- EQUALS: =
- NOT EQUALS: !=
- IN
- CONTAINS: ~

##### Only for date values and numbers
- GREATER THAN: >
- GREATER THAN EQUALS: >=
- LESS THAN: <
- LESS THAN EQUALS: <=

### Keywords

A keyword in TQL is a word or phrase that does (or is) any of the following:

- joins two or more clauses together to form a complex TQL query
- alters the logic of one or more clauses
- alters the logic of operators
- has an explicit definition in a TQL query
- performs a specific function that alters the results of a TQL query.

#### List of keywords (for the matter of this test)

- AND
- OR

## TQL samples


	GET /tickets?tql=id = 2

	GET /tickets?tql=id in (1, 3, 4)

	GET /tickets?tql=description ~ "sleep" AND author = "Irmão do Jorel"

	GET /tickets?tql=updated >= 2019-02-10 OR author = "Irmão do Jorel"

	GET /tickets?tql=updated >= 2019-02-10 AND id in (1,2,3)


## Data set


```json
{
  "tickets": [
    {
      "id": 1,
      "description": "make my bed",
      "author": "Irmão do Jorel",
      "creationDate": 2019-01-12 12:32:00
    },
    {
      "id": 2,
      "description": "let me sleep",
      "author": "Washington Listinha",
      "creationDate": 2018-11-20 01:30:00
    },
    {
      "id": 3,
      "description": "who ate my brownie?",
      "author": "Dani Kelton",
      "creationDate": 2019-02-05 06:00:00
    },
    {
      "id": 4,
      "description": "what about my birthday?",
      "author": "Sandy",
      "creationDate": 2019-02-02 12:24:00
    },
    {
      "id": 5,
      "description": "Mine is better",
      "author": "Labs",
      "creationDate": 2019-02-06 17:30:00
    },
    {
      "id": 6,
      "description": "where are my coupons?",
      "author": "iMeal app",
      "creationDate": 2015-10-30 12:43:00
    },
    {
      "id": 7,
      "description": "play Beyoncé!",
      "author": "Praxedes",
      "creationDate": 2019-01-01 00:00:00
    },
    {
      "id": 8,
      "description": "I need another job",
      "author": "David Brasil",
      "creationDate": 2018-06-26 23:45:22
    },
    {
      "id": 9,
      "description": "where's the bathroom?",
      "author": "Yohannes",
      "creationDate": 2015-10-03 17:36:24
    },
    {
      "id": 10,
      "description": "I quit!",
      "author": "Number 2",
      "creationDate": 2018-05-26 10:45:20
    }
  ]
}
```

**No match**

    GET /tickets?tql=id = 11

```json
{
  "tickets": []
}
```


### Non-functional

- All code should be written in ASP.NET Core 2+ (C#)
- Onion archtecture is a plus (https://docs.microsoft.com/en-us/dotnet/standard/modern-web-apps-azure-architecture/common-web-application-architectures / https://github.com/dotnet-architecture/eShopOnWeb/tree/master/src)
- Challenge is submitted as pull request against this repo ([fork it](https://confluence.atlassian.com/bitbucket/forking-a-repository-221449527.html) and [create a pull request](https://confluence.atlassian.com/bitbucket/create-a-pull-request-to-merge-your-change-774243413.html))
- Documentation and maintainability is a plus

## Getting Started

Begin by forking this repo and cloning your fork.

## Important tip!

Something is better than nothing, even if it is less than we wanted.
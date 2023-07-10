# RetailStore

## Structure

![ShopsRUs drawio](https://github.com/ybalcin/RetailStore/assets/47143192/72f18b3c-9a82-4f29-ba3d-8c853f2a427c)

ProductCategory;
"grocery",
"not_grocery"

UserType;
"employee",
"affiliate"

DiscountType;
"cash",
"percentage"

## Test

### Run Tests
```shell
cd RetailStore
dotnet test
```

## API

* `POST /api/invoice`: accepts BillDto, returns InvoiceDto

BillDto
```json
{
    "customer": {
        "type": "affiliate"
    },
    "basket": [
        {
            "product": {
                "category": "not_grocery",
                "price": 100
            },
            "count": 2
        },
        {
            "product": {
                "category": "not_grocery",
                "price": 200
            }
        }
    ]
}
```

InvoiceDto
```json
{
    "bill": {
        "customer": {
            "type": "affiliate",
            "createdAt": "2023-07-11T01:41:37.686516+03:00"
        },
        "basket": [
            {
                "product": {
                    "category": "not_grocery",
                    "price": 100
                },
                "count": 2
            },
            {
                "product": {
                    "category": "not_grocery",
                    "price": 200
                },
                "count": 1
            }
        ]
    },
    "gross": 400,
    "net": "358,34"
}
```

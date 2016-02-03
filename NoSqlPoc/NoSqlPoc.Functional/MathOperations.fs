//namespace NoSqlPoc.Functional

//type Class1() = 
//    member this.X = "F#"

module NoSqlPoc.Functional.MathOperations

    let add a b = 
        a + b

    let impactTL (tlrelevant:bool) (plan:System.Decimal) (update:System.Decimal) (relative:System.Decimal) = 
        if (((update - plan) / plan * (decimal)100.0) > relative) then "green"
        else "red"


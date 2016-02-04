//namespace NoSqlPoc.Functional

//type Class1() = 
//    member this.X = "F#"

module NoSqlPoc.Functional.MathOperations

    let add a b = 
        a + b

    type TrafficLightColor =
        | White=0
        | Black=1
        | Green=2
        | Yellow=3
        | Red=4

    let impactTL (mstlrelevant:bool) (impacttlrelevant:bool) (plan:System.Decimal) (update:System.Decimal) (relative:System.Decimal) = 
        if (mstlrelevant = false) then TrafficLightColor.Black
        elif () then TrafficLightColor.White
        else TrafficLightColor.Black


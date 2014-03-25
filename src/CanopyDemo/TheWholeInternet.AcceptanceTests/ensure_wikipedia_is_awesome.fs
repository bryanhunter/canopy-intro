module ensure_wikipedia_is_awesome

open System
open canopy
open runner

let all _ =
    context "Ensure Wikipedia is Awesome"

    let root = "http://en.wikipedia.org/wiki/Main_Page"
    let alonzo_church_article = "http://en.wikipedia.org/wiki/Alonzo_Church"
    let fp_article = "http://en.wikipedia.org/wiki/Functional_programming"

    """GIVEN I am visiting Wikipedia
        WHEN I type Alonzo Church in the search box 
            AND hit enter
        THEN I am presented the Alonzo Church artcle""" &&& (fun _ ->
            url root
            on root

            "#searchInput" << "Alonzo Church\r\n"

            on alonzo_church_article
            )

    """GIVEN I am viewing the "Alonzo Church" article on Wikipedia
       WHEN I find and click the "functional programming" link
       THEN I am presented with the "Functional Programming" article""" &&& (fun _ ->
            url alonzo_church_article
            on alonzo_church_article
       
            let fpLink = "a[title='Functional programming']"
            click fpLink

            on fp_article
       )
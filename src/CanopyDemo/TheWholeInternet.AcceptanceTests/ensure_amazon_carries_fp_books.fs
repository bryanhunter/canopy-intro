module ensure_amazon_carries_fp_books

open System
open canopy
open runner

let all _ =
    context "Ensure Wikipedia is Awesome"

    let root = "http://www.amazon.com/"
    let joesBook = "http://www.amazon.com/Programming-Erlang-Concurrent-Pragmatic-Programmers/dp/193778553X"

    """GIVEN I am visiting Amazon's website
        WHEN I search for "Erlang"
        THEN I am presented with a wealth of amazing titles""" &&& (fun _ ->
        
        url root
        on root

        "#twotabsearchtextbox" << "Erlang"

        click "#nav-searchbar input[type=submit]"

        let armstrongLink = element("a[href *= 'Programming-Erlang-Concurrent-Pragmatic-Programmers/dp/193778553X']")

        click armstrongLink
        )

    """GIVEN I have found Joe Armstong's new book on Amazon
        WHEN I click Add to Cart
        THEN my cart shows one item""" &&&& (fun _ -> 
        
            url joesBook

            click "#bb_atc_button"
            
            let quantityInCart = "#nav-cart-count"
            contains "1" (read quantityInCart)
    
        )
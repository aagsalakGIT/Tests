*** Settings ***
Documentation     Simple example using SeleniumLibrary.
Library           SeleniumLibrary

*** Variables ***
${LOGIN URL}        https://www.asos.com/
${BROWSER}          firefox
${products}         class:_2r9Zh0W


*** Test Cases ***
Valid Login
    Launch Browser And Navigate To Webpage
    Close Popup
    Search For An Item   sunglasses
    Sort Items By Price High to Low
    Add Items To List  0
    Add Item To Checkout
    Go Back To Result Page
    Sort Items By Price High to Low
    Add Items To List  1
    Add Item To Checkout


*** Keywords ***
Launch Browser And Navigate To Webpage
    Open Browser    ${LOGIN URL}    ${BROWSER}
    Maximize Browser Window

Search For An Item
    [Arguments]    ${item}
    Input Text    chrome-search    ${item}
    Wait
    Click Button  xpath://button[@class='H2J6qLQ _3Q1IVqO']

Sort Items By Price High to Low
    Click Button     xpath://button[@class='_1om7l06']
    Click Element    id:plp_web_sort_price_high_to_low
    Wait

Add Items To List
    [Arguments]    ${num}
    ${elem}=     Get WebElements     class:_2r9Zh0W
    Select Items On Product List Page   ${elem}[${num}]

Select Items On Product List Page
    [Arguments]    ${item}
    Scroll Element Into View    ${item}
    Click Element               ${item}

Add Item To Checkout
    Wait
    Assign ID to Element               id:product-add                    addToBasket
    Click Element                      xpath://span[@data-bind='text: buttonText']

Go Back To Result Page
    Go To       https://www.asos.com/search/?q=sunglasses


Close Popup
    Click Element              xpath://span[@class='_19aAF1K -rhP1cz gBrrjX4 _2nHArcS']

Wait
    Sleep   3

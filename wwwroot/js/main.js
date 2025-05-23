﻿document.addEventListener('DOMContentLoaded', function () {

    //
   
        let imgElemnt = document.querySelector(".banner .container .content img");
        let Bullets = document.querySelectorAll('.banner .container .content .bullet span');
        let leftArrow = document.querySelector('.banner .container .left-icon');
        let rightArrow = document.querySelector('.banner .container .right-icon');


        let productOptions = document.querySelectorAll(".card #optionClick i");



        let specialCategoeryContainer = document.querySelector('.special-Category .container .row');
        let btnRightSpecialCategory = document.querySelector('.special-Category .arrows .bi-arrow-right');
        let btnLeftSpecialCategory = document.querySelector('.special-Category .arrows .bi-arrow-left');


        let arrowleftNew = document.querySelector('.new-category .container .arrows .arrow-left');
        let arrowrightNew = document.querySelector('.new-category .container .arrows .arrow-right');
        let productNew = document.querySelectorAll('.new-category .container .row .card');

        let changePhotoInterval;
        let navItems = document.querySelectorAll(".navbar-nav .nav-item");
         console.log(navItems);
         console.log(window.location.pathname);
        for (let i = 0; i < navItems.length; i++) { 
            navItems[i].addEventListener("click", function (eventInfo) {
                let currentItemNav = eventInfo.currentTarget; // Ensure getting the right element
                eventInfo.target.children[0].preventDefault();
                console.log("Current Item Nav", currentItemNav);
                // If click was outside a .nav-item, do nothing

                let otherChildren = currentItemNav.parentElement.children; // Get all siblings


                for (let element = 0; element < otherChildren.length; element++) {
                    
                    otherChildren[element].classList.remove("active-link-in-nav");
                   
                 }

                currentItemNav.classList.add("active-link-in-nav"); // Add active class
            });
        }



        // loader Function
        let loader = () => {
            $(".loader").fadeOut(500, function () {
                $("#loading").fadeOut(500, function () {
                    $('body').css('overflow', 'auto');
                    $('#loading').remove();
                })
            })
        }
        loader();


        // Cart Info  open and close cart

        $(".topnav .bi-cart").click(function () {
            $(".background").css("display", "block");
        $(".cartInfo").animate({right: '0' }, 500);
        $('body').addClass('hide-scrollbar-thumb');
        });


        $(".cartInfo .header .closeBtn").click(function () {

            $(".cartInfo").animate({ right: '-500px' }, 500, function () {
                document.querySelector(".background").style.display = 'none';
                $('body').removeClass('hide-scrollbar-thumb');
            });

        });
    
        //*****************banner**********************/
    if(window.location.pathname==='/'){
   
            function changePhotoDynamic() {
                let urlimg = imgElemnt.getAttribute('src');
                if (urlimg === '/images/main-banner-1-1600x700.jpg') {

                    imgElemnt.setAttribute('src', '/images/main-banner-2-1600x700.jpg');
                    Bullets[0].classList.remove('active-bullet');
                    Bullets[1].classList.add('active-bullet');
                }
                else {

                    imgElemnt.setAttribute('src', '/images/main-banner-1-1600x700.jpg');
                    Bullets[0].classList.add('active-bullet');
                    Bullets[1].classList.remove('active-bullet');
                }
            }
    
            // change img dynamic
            changePhotoInterval = setInterval(changePhotoDynamic, 3000);


            // change photo on click arrow
            leftArrow.addEventListener('click', function () {
                 clearInterval(changePhotoInterval);
                changePhotoDynamic();               
                changePhotoInterval = setInterval(changePhotoDynamic, 5000);
            }, { passive: true });
            rightArrow.addEventListener('click', function () {
                clearInterval(changePhotoInterval);
                changePhotoDynamic();
                changePhotoInterval = setInterval(changePhotoDynamic, 5000);
            }, { passive: true });

    }
        //***************************************************** */


        // Take Action when Click on product addTocCart , addToFavourit , seeMoreInfo
        for (let i = 0; i < productOptions.length; i++) {

            productOptions[i].addEventListener('click', function (eventInfo) {
                let className = eventInfo.target.className;


                if (className === "fa-solid fa-eye") {

                    let imgSrc = eventInfo.target.parentElement.previousElementSibling.getAttribute('src');
                    let productName = eventInfo.target.parentElement.parentElement.nextElementSibling.children[1].innerHTML;
                    let productPrice = eventInfo.target.parentElement.parentElement.nextElementSibling.children[2].innerHTML;


                    document.querySelector(".productInfo").classList.remove('d-none');
                    document.querySelector(".productInfo").classList.add('d-block');


                    document.querySelector(".productInfo .moreinfo .image img").setAttribute('src', imgSrc);
                    document.querySelector(".productInfo .moreinfo .name span").innerHTML = ` ${productName}`;
                    document.querySelector(".productInfo .moreinfo .price span").innerHTML = ` ${productPrice}`;

                }
               

                // Add to favorite
                else if (className === 'fa-regular fa-heart') {

                    let CheckColor = window.getComputedStyle(eventInfo.target).color;
                    if (CheckColor == 'rgb(255, 255, 255)') {

                        eventInfo.target.style.color = 'red';
                    }
                    else
                        eventInfo.target.style.color = 'rgb(255, 255, 255)';

                }

            });
        }

        document.querySelector('.productInfo .closeBtn').addEventListener('click', function () {
            document.querySelector(".productInfo").classList.add('d-none')
        });
       

        //************************** Slider of Special Category *************************** *//
       
    if (window.location.pathname === '/') {
        let cardOfSpecialProdutc = document.querySelector('.special-Category .container .row .card');
        let cardWidth;
        var WidthOfScroll;

        //Scroll using mouse

        let mob_view_Special = window.matchMedia("(max-width:576px)");
        specialCategoeryContainer.addEventListener('wheel', function (eventInfo) {
            if (!mob_view_Special.matches) {

                eventInfo.preventDefault();
                specialCategoeryContainer.scrollBy({
                    left: eventInfo.deltaY,
                });
            }
        });

        // using buttons

        btnRightSpecialCategory.addEventListener('click', function () {

            cardWidth = cardOfSpecialProdutc.offsetWidth;
            WidthOfScroll = cardWidth;

            // specialCategoeryContainer.scrollLeft += WidthOfScroll;
            specialCategoeryContainer.scrollBy({
                left: WidthOfScroll,
                behavior: "smooth"
            });
        });


        btnLeftSpecialCategory.addEventListener('click', function () {

            cardWidth = cardOfSpecialProdutc.offsetWidth;
            WidthOfScroll = cardWidth;

            specialCategoeryContainer.scrollBy({
                left: -WidthOfScroll,
                behavior: "smooth"
            });

        });
        ///////////////////////////////////////////////////////////////////

        //****************************Slider of new*********************************/

        let width_product_New = document.querySelector('.new-category .container .row .card');
        let ContainerOfProduct = document.querySelector('.new-category .container .row');
        // let Visible_part=product_Section_New.clientWidth;


        let Tolast = 0;
        let movePer;
        let Visible_part = ContainerOfProduct.clientWidth;
        let maxMove = ContainerOfProduct.scrollWidth;   // last of move
        let numPhotoView = 4;


        let com_view = window.matchMedia("(max-width: 990px)");
        if (com_view.matches) {
            //movePer =(Visible_part / 3) +5;
            numPhotoView = 3;
        }

        let tab_view = window.matchMedia("(max-width: 767px)");
        if (tab_view.matches) {
            //movePer =(Visible_part / 2) ;
            numPhotoView = 2;
        }


        let mob_view = window.matchMedia("(max-width: 576px)");
        if (mob_view.matches) {
            //movePer =Visible_part-30;
            numPhotoView = 1;
        }

        let Right_Mover = () => {
            movePer = width_product_New.offsetWidth + 10;

            Tolast += movePer;
            if (Tolast > maxMove - movePer * numPhotoView) {

                console.log("hello");


                Tolast = Tolast - movePer;
            }
            for (const i of productNew) {
                i.style.left = '-' + Tolast + 'px';
            }

            console.log(movePer);

        }

        let Left_Mover = () => {
            movePer = width_product_New.offsetWidth + 10;
            Tolast -= movePer;
            if (Tolast < 0) {
                Tolast = 0;
            }
            else if (Tolast > maxMove - movePer * numPhotoView) {
                Tolast = 0;
            }

            for (const i of productNew) {
                i.style.left = '-' + Tolast + 'px';
            }
        }

        arrowleftNew.addEventListener('click', function () {
            Left_Mover();
        });

        arrowrightNew.addEventListener('click', function () {
            Right_Mover();
        });
    }

});

// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Enable Bootstrap tooltips
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl);
});

(function () {
    emailjs.init("service_4ukdtdo"); // Replace with your EmailJS User ID
})();

function sendConfirmationEmail() {
    const orderDetails = {
        customerName: "@Model.CustomerName",
        totalAmount: "@Model.TotalAmount",
        shippingFee: "@Model.ShippingFee",
        orderDate: "@Model.OrderDate.ToLocalTime().ToString("f")",
        streetAddress: "@Model.StreetAddress",
        villageOrSuburb: "@Model.VillageOrSuburb",
        city: "@Model.City",
        areaCode: "@Model.AreaCode",
        orderStatus: "@Model.Status",
    };

    const templateParams = {
        customer_name: orderDetails.customerName,
        total_amount: orderDetails.totalAmount,
        shipping_fee: orderDetails.shippingFee,
        order_date: orderDetails.orderDate,
        delivery_address: `${orderDetails.streetAddress}, ${orderDetails.villageOrSuburb}, ${orderDetails.city}, ${orderDetails.areaCode}`,
        order_status: orderDetails.orderStatus,
        customer_email: "@Model.Email",  // Assuming you have an Email property in your model
        business_email: "business@example.com"  // Replace with the business email
    };

    // Send email to the customer
    emailjs.send("service_4ukdtdo", "template_z5j3jeq", templateParams)
        .then(function (response) {
            console.log("Email sent successfully", response);
        }, function (error) {
            console.error("Email send failed", error);
        });

//billing final amaount due *******************************

    

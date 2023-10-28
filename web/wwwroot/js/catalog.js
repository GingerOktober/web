$(document).ready(function () {
    $('.card').click(function () {
        var goodId = $(this).data('goodid');

        $.ajax({
            url: '/Home/GetProductInfo',
            type: 'GET',
            data: { goodId: goodId },
            success: function (productInfoList) {
                $('.modal').remove();
                productInfoList.forEach(function (productInfo) {
                    var modal = `
                    <div class="modal fade" id="productModal-${goodId}" tabindex="-1" role="dialog" aria-labelledby="productModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="productModalLabel">${productInfo.Name}</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div class="modal-image-container" style="float: left; margin-right: 10px;">
                    <img src="${productInfo.Image}" class="modal-image" style="max-width: 200px; max-height: 200px; border: 10px solid purple; border-radius: 5px;" />
                </div>
                <div class="modal-text">
                    <p class="modal-price" style="color: green;">Цена: ${productInfo.Price}</p>
                    <p class="modal-old-price" style="color: black;">Старая цена: <s>${productInfo.OldPrice}</s></p>
                    <div style="clear: both;"></div>
                </div>
                <div class="modal-description" style="background-color: #eaeaea; padding: 10px; border: 1px solid #ccc; border-radius: 5px; margin-top: 10px;">
                    <p style="color: #484343; font-size: 16px; font-weight: 400; line-height: 24px; text-align: left;"><b>Краткое описание:</b> ${productInfo.ShortDescription}</p>
                    <p style="color: #484343; font-size: 16px; font-weight: 400; line-height: 24px; text-align: left;"><b>Подробное описание:</b> ${productInfo.Description}</p>
                </div>
                <p class="modal-info" style="color: #707070; font-size: 14px; font-style: italic; line-height: 16px;">Дополнительная информация:</p>
                <ul>
                    <li><b>Тип:</b> ${productInfo.Type}</li>
                    <li><b>Объем:</b> ${productInfo.Volume}</li>
                    <li><b>Категория:</b> ${productInfo.Category}</li>
                    <li><b>Страна производства:</b> ${productInfo.Country}</li>
                    <li><b>Дополнительные характеристики:</b> ${productInfo.DopCharact}</li>
                </ul>
            </div>
        </div>
    </div>
</div>

                `;

                    $('body').append(modal);
                    $(`#productModal-${goodId}`).modal('show');
                });
            },
            error: function () {
                console.log("Ошибка при получении информации о товаре.");
            }
        });
    });
});

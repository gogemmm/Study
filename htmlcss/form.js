document.addEventListener('DOMContentLoaded', function() {
    var function1Btn = document.getElementById('function1');
    var contentDiv = document.getElementById('content');

    function1Btn.addEventListener('click', function(event) {
        event.preventDefault(); // 阻止默认链接行为

        // 创建并插入表单页面
        var formHTML = `
            <form>
                <!-- 在此处添加表单内容 -->
                <label for="name">姓名：</label>
                <input type="text" id="name" name="name">
                <label for="email">邮箱：</label>
                <input type="email" id="email" name="email">
                <!-- 添加更多表单字段 -->
                <button type="submit">提交</button>
            </form>
        `;
        contentDiv.innerHTML = formHTML;
    });
});

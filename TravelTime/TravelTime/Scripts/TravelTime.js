$(document).ready(function () {
    $('#Railway,#Bus,#Taxi,#Map,#Table').hide();
    $('#tabs div:first').show();
    //      $('#tabs ul:first').addClass('navi_tz');

    $('#tabs ul a').click(function () {
        //                        $('#tabs ul').removeClass('navi_tx');
        //                        $('#tabs ul').addClass('navi_tz');
        //                        $(this).parent().addClass('navi_tz');
        var currentTab = $(this).attr('href');
        // $('#tabs div ').hide();
        $(currentTab).show();
        if (currentTab == '#Locate') {
            $('#tabs div').show();
            $('#Railway,#Bus,#Taxi,#Map,#Table').hide();
        }
        if (currentTab != '#Locate') {
            $('#tabs div').hide();
            $(currentTab).show();
        }
        if (currentTab == '#Map') {
            $('#tabs div').show();
            $('#Railway,#Bus,#Taxi,#Locate,#Table').hide();
        }
        return false;
    });
});
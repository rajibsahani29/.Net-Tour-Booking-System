<?php

//Import PHPMailer classes into the global namespace
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;
use PHPMailer\PHPMailer\SMTP;

require( "PHPMailer.php" );
require( "Exception.php" );
require( "SMTP.php" );

$mail = new PHPMailer(true);

$email = 'dontreply@easyways.com';
$password = 'i-am-the-egg-man';
$to_id = 'kyle@bluesword.org';
$message = 'test';
$subject = 'subject';
$host = 'smtp.gmail.com';
$from_name = "Easyways";

$mail = new PHPMailer;
$mail->isSMTP();
$mail->From = $email;
$mail->FromName = $from_name;
$mail->Host = $host;
//$mail->Port = 587;
//$mail->SMTPSecure = 'tls';
$mail->Port = 465;
$mail->SMTPSecure = 'ssl';
$mail->SMTPAuth = true;
$mail->Username = $email;
$mail->Password = $password;
$mail->addAddress($to_id);
$mail->Subject = $subject;
$mail->msgHTML($message);
if (!$mail->send()) {
  echo $mail->ErrorInfo;
} else {
  echo 'email sent';
}

?>
